$(function () {

    $("#SubjectFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#SubjectFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#SubjectFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/SubjectFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('QLHS');

    var service = qLHS.subjects.subject;
    var createModal = new abp.ModalManager(abp.appPath + 'Subjects/Subject/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Subjects/Subject/EditModal');

    var dataTable = $('#SubjectTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('QLHS.Subject.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('QLHS.Subject.Delete'),
                                confirmMessage: function (data) {
                                    return l('SubjectDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('SubjectSubjectName'),
                data: "subjectName"
            },
            {
                title: l('SubjectTypeSubject'),
                data: "typeSubject",
                render: function (data) {
                    return l('Enum:MonHoc' + data)
                }
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSubjectButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
