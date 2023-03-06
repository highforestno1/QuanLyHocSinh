
$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Teachers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Teachers/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Teachers/ViewModal');
    var l = abp.localization.getResource('QLHS');
    var teacherService = qLHS.teachers.teacher;
    var query = () => {
        return {'queryName': $("#NameSearch").val()}
    }
    $("#NameSearch").on("input", (n) => {
        console.log("A")
        dataTable.ajax.reload();
    })
    var dataTable = $('#TeachersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(teacherService.getList, query),
            columnDefs: [
                {
                    title: l('Teacher:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Teacher:Edit'),
                                    action: function (data) {
                                        editModal.open({id: data.record.id});
                                    }
                                },{
                                    text: l('Teacher:View'),
                                    action: function (data) {
                                        viewModal.open({id: data.record.id});
                                    }
                                },
                                {
                                    text: l('Teacher:Delete'),
                                    confirmMessage: function (data) {
                                        return "Are you sure to delete the teacher '" + data.record.name + "'?";
                                    },
                                    action: function (data) {
                                        teacherService
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info('Successfully deleted!');
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Teacher:Name'),
                    data: "name"
                },
                {
                    title: l('Teacher:BirthDate'),
                    data: "birthDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DateTime);
                    }
                },
                {
                    title: l('Teacher:Address'),
                    data: "address"
                },
                {
                    title: l('Teacher:PhoneNumber'),
                    data: "phoneNumber"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTeacherButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
