$(function () {
    var l = abp.localization.getResource("Tutorial");

    var bookService = window.wTECHIN.tutorial.books.book;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Books/CreateModal",
        scriptUrl: abp.appPath + "Pages/Books/createModal.js",
        modalClass: "bookCreate"
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Books/EditModal",
        scriptUrl: abp.appPath + "Pages/Books/editModal.js",
        modalClass: "bookEdit"
    });

    var dataTableColumns = [
        {
            rowAction: {
                items:
                    [
                        {
                            text: l("Edit"),
                            visible: abp.auth.isGranted('Tutorial.Books.Edit'),
                            action: function (data) {
                                editModal.open({
                                    id: data.record.id
                                });
                            }
                        },
                        {
                            text: l("Delete"),
                            visible: abp.auth.isGranted('Tutorial.Books.Delete'),
                            confirmMessage: function () {
                                return l("DeleteConfirmationMessage");
                            },
                            action: function (data) {
                                bookService.delete(data.record.id)
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
        { data: "type" },
        { data: "publishDate" },
        { data: "price" },
    ];

    var dataTable = $("#BooksTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(bookService.getList),
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

    $("#NewBookButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
