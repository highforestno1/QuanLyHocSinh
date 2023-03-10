
$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Students/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Students/EditModal');
    var viewModal = new abp.ModalManager(abp.appPath + 'Students/ViewModal');
    var l = abp.localization.getResource('QLHS');
    var query = () => {
        return {'queryName': $("#NameSearch").val()}
    }
    $("#NameSearch").on("input", (n) => {
            console.log("A")
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
                    title: l('Student:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Student:Edit'),
                                    action: function (data) {
                                        editModal.open({id: data.record.id});
                                    }
                                },
                                {
                                    text: l('Student:View'),
                                    action: function (data) {
                                        viewModal.open({id: data.record.id});
                                    }
                                },
                                {
                                    text: l('Student:Delete'),
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
                    title: l('Student:Name'),
                    data: "name"
                },
                {
                    title: l('Student:Dob'),
                    data: "dob",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DateTime);
                    }
                },
                {
                    title: l('Student:TeacherName'),
                    data: "teacherName"
                },
                {
                    title: l('Student:Address'),
                    data: "address"
                },
                {
                    title: l('Student:Rank'),
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
