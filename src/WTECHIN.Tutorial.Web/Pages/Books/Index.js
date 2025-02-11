$(function () { //Bu satır, sayfa tamamen yüklendiğinde kodun çalışmasını sağlar.

    var l = abp.localization.getResource('Tutorial'); //LocalizationResourceName("Tutorial") olarak tanımlı o yüzden böyle eriştim
    var service = window.wTECHIN.tutorial.books.book;
    var dataTable = $('#BooksTable').DataTable( //HTML içinde bulunan id="BooksTable" olan tabloyu seçer ve onu bir DataTable nesnesine çevirir.DataTable: Dinamik veri yükleyebilen, sıralama, sayfalama ve filtreleme özellikleri sunan gelişmiş bir tablo yapısıdır.
        abp.libs.datatables.normalizeConfiguration({
            //            ABP Framework’e özel olarak DataTable ayarlarını normalize eder.
            //Bu yapı, ABP'nin DataTables entegrasyonunu kullanmayı kolaylaştırır.
            serverSide: true, //Veriler sunucu tarafından yüklenecek, yani tablo API’den dinamik olarak veri çekecek.Veriler doğrudan veritabanından çekilecek.
            paging: true, //Sayfalama açık olacak
            order: [[1, "asc"]],//Varsayılan olarak 1. sütunu artan (A-Z) şekilde sıralayacak.
            searching: false, // Kullanıcı tablonun içeriğinde arama yapamayacak
            scrollX: true, // Yatay kaydırma açık olacak.
            ajax: abp.libs.datatables.createAjax(service.getList),//Tablonun verilerini sunucudan almasını sağlar.
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:BookType.' + data);
                    }
                },
                {
                    title: l('PublishDate'),
                    data: "publishDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
});
