$(function () {
    var l = abp.localization.getResource("Tutorial");

    var authorService = window.wTECHIN.tutorial.authors.author;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Authors/CreateModal",
        scriptUrl: abp.appPath + "Pages/Authors/createModal.js",
        modalClass: "authorCreate"
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Authors/EditModal",
        scriptUrl: abp.appPath + "Pages/Authors/editModal.js",
        modalClass: "authorEdit"
    });

    var dataTableColumns = [
        {
            rowAction: {
                items:
                    [
                        {
                            text: l("Edit"),
                            visible: abp.auth.isGranted('Tutorial.Authors.Edit'),
                            action: function (data) {
                                editModal.open({
                                    id: data.record.id
                                });
                            }
                        },
                        {
                            text: l("Delete"),
                            visible: abp.auth.isGranted('Tutorial.Authors.Delete'),
                            confirmMessage: function () {
                                return l("DeleteConfirmationMessage");
                            },
                            action: function (data) {
                                authorService.delete(data.record.id)
                                    .then(function () {
                                        abp.notify.success(l("SuccessfullyDeleted"));
                                        dataTable.ajax.reloadEx();
                                    });
                            }
                        }
                    ]
            },
            width: "1rem"
        },
        { data: "name" },
        { data: "birthDate" },
        { data: "shortBio" },
    ];

    var dataTable = $("#AuthorsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(authorService.getList),
        columnDefs: dataTableColumns,
        lengthMenu: [10, 25, 50, 100, 250, 500, 1000],
        pageLength: 50
    }));

    createModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    editModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    $("#NewAuthorButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
