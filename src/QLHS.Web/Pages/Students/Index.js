$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Students/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Students/EditModal');
    // var searchQuery = $("input").attr("aria-controls").val()
    var query = () => {
        return {'queryName': $("#NameSearch").val()}
    }
    $("#NameSearch").on("input", (n) => {
            console.log("A")
            dataTable.ajax.reload();
        })
    var queryAddress = () => {
        return {'queryName': $("#AddressSearch").val()}
    }
    $("#AddressSearch").on("input", (a) => {
        dataTable.ajax.reload();
    })
    
    var studentService = qLHS.students.student;
    var dataTable = $('#StudentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(studentService.getList, query)
            ,
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
                                },
                                {
                                    text: 'Delete',
                                    confirmMessage: function (data) {
                                        return "Are you sure to delete the student '" + data.record.name + "'?";
                                    },
                                    action: function (data) {
                                        studentService
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info("Successfully deleted!");
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
                    title: 'Date Of Birth',
                    data: "dob",

                },
                {
                    title: 'Teacher Name',
                    data: "teacherName"
                },
                {
                    title: 'Address',
                    data: "address"
                },
                {
                    title: 'Rank',
                    data: "roomNames",
                    render: function (data) {
                        return data.join(", ");
                    }
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

    $('#NewStudentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
