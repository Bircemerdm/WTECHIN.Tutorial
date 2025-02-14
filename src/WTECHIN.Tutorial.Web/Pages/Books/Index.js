$(function () { //Bu satır, sayfa tamamen yüklendiğinde kodun çalışmasını sağlar.

    var l = abp.localization.getResource('Tutorial'); //LocalizationResourceName("Tutorial") olarak tanımlı o yüzden böyle eriştim
    var service = window.wTECHIN.tutorial.books.book; //java script saçma bir şekilde w yi küçültmeni istiyor

    var createModal = new abp.ModalManager(abp.appPath + "Books/CreateModal"); //abp.ModalManager → ABP'nin modal (açılır pencere) yönetimini sağlayan sınıfıdır.ABP projelerinde appPath, uygulamanın kök dizinini temsil eder.

    var editModal = new abp.ModalManager(abp.appPath + "Books/EditModal");

    var dataTable = $('#BooksTable').DataTable( //HTML içinde bulunan id="BooksTable" olan tabloyu seçer ve onu bir DataTable nesnesine çevirir.DataTable: Dinamik veri yükleyebilen, sıralama, sayfalama ve filtreleme özellikleri sunan gelişmiş bir tablo yapısıdır.
        abp.libs.datatables.normalizeConfiguration({
            //ABP Framework’e özel olarak DataTable ayarlarını normalize eder.
            //Bu yapı, ABP'nin DataTables entegrasyonunu kullanmayı kolaylaştırır.
            serverSide: true, //Veriler sunucu tarafından yüklenecek, yani tablo API’den dinamik olarak veri çekecek.Veriler doğrudan veritabanından çekilecek.
            paging: true, //Yani tablodaki tüm kitaplar tek seferde değil, belirli sayıda gösterilecek ve kullanıcı sayfalar arasında gezinebilecek.
            order: [[1, "asc"]],//Varsayılan olarak 1. sütunu artan (A-Z) şekilde sıralayacak.
            searching: false, // Kullanıcı tablonun içeriğinde arama yapamayacak
            scrollX: true, // Yatay kaydırma açık olacak.
            ajax: abp.libs.datatables.createAjax(service.getList),//Tablonun verilerini sunucudan almasını sağlar.

            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                    //Bu, düğmeye tıklandığında çalışacak olan fonksiyondur.Parametre olarak data alıyor. data, tıklanan satırın verilerini içerir.
                                       
                                        editModal.open({ id: data.record.id });// record satırdaki datanın tamamını tutuyor id ile de sadece id sine erişti
                                    }
                                }
                            ]
                    }
                },
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
                    dataFormat: "datetime"
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );
    createModal.onResult(function(){ //onResult(function () { ... })
        //Modal kapatıldığında çalışacak kodu tanımlar.
        //Kullanıcı kitap eklediğinde veya modalı kapattığında çağrılır.
        dataTable.ajax.reload(); //DataTable'daki verileri yeniden yükler. böylece yeni yüklenen kitap görünür
    });
    editModal.onResult(function () {
        console.log("çalış")
        dataTable.ajax.reload();
        
    });
    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open(); //Modalı açar, yani kitap ekleme formunu gösterir.
    });
   
});
