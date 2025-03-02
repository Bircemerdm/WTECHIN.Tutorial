$(function () {
    var l = abp.localization.getResource('Tutorial');
    var createModal = new abp.ModalManager(abp.appPath + 'Authors/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Authors/EditModal');
    var service = window.wTECHIN.tutorial.authors.author
    var dataTable = $('#AuthorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(service.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('Tutorial.Authors.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('Tutorial.Authors.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AuthorDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        service
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                                //DataTable'ın verilerini yeniden yüklemek ve yeniden render etmek için kullanılan bir yöntemdir. Bu metodun kullanımını adım adım açıklayayım:
                                            //sayfayı yeniden yüklemeye gerek kalmadan tablonun içeriklerinin güncellenmesi sağlanır.
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name" //data: DataTable'da her bir satır için veri alındığında, hangi verinin hangi kolona yerleştirileceğini belirleriz.
                //"name", gelen verinin JSON yapısındaki bir anahtarı temsil eder.
                },
                {
                    title: l('BirthDate'),
                    data: "birthDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    //render kullanarak, verinin dil veya kültür farkına göre doğru formatta gösterilmesini sağlıyoruz
                    }
                    
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    //modal pencerelerinin kapatılmasından sonra DataTable'ı yenilemektir

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAuthorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
