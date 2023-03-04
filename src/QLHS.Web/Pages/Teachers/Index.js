$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Teachers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Teachers/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Teachers/ViewModal');

    var teacherService = qLHS.teachers.teacher;

    var dataTable = $('#TeachersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(teacherService.getList),
            columnDefs: [
                {
                    title: 'Actions',
                    rowAction: {
                        items:
                            [
                                {
                                    text: 'Edit',
                                    action: function (data) {
                                        editModal.open({id: data.record.id});
                                    }
                                },{
                                    text: 'View',
                                    action: function (data) {
                                        viewModal.open({id: data.record.id});
                                    }
                                },
                                {
                                    text: 'Delete',
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
                    title: 'Name',
                    data: "name"
                },
                {
                    title: 'BirthDate',
                    data: "birthDate"
                },
                {
                    title: 'Address',
                    data: "address"
                },
                {
                    title: 'PhoneNumber',
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
