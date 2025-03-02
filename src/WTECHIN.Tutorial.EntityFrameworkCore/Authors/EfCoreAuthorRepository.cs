using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WTECHIN.Tutorial.EntityFrameworkCore;

namespace WTECHIN.Tutorial.Authors;

public class EfCoreAuthorRepository: EfCoreRepository<TutorialDbContext, Author,Guid>, IAuthorRepository
{
    //ilk parametri kullanılacak db sınıfı veritabanı bağlantısı burdan sağlanır. author entity sınıfı yönetilecek varlıktır. guid primary key olarak kullanılır.

    public EfCoreAuthorRepository(
        IDbContextProvider<TutorialDbContext> dbContextProvider) : base(dbContextProvider)
    {
        
    }

    public async Task<Author> FindByNameAsync(string name)
    {
        var dbSet= await GetDbSetAsync();//Bu metot, ABP'nin EfCoreRepository<TDbContext, TEntity, TKey> sınıfı içinde tanımlıdır.veritabanı tablosuna asenkron olarak erişen bir methoddur
        return await dbSet.FirstOrDefaultAsync(author=> author.Name == name); //Name alanı verilen name değişkenine eşit olan ilk yazarı getirir.
    }//bu kısımdaki author veritabanında her bir satırı temsil eden bir nesnedir
    public async Task<List<Author>> GetListAsync(
        int skipCount, //kayıt atlamak
        int maxResultCount, //Kaç kayıt döndürüleceğini belirler.
        string sorting, //3. parametreye göre alfabetik sıralar
        string filter = null) //filtreye uygun yazarlar getirilir
                             
    //yazarları listelemek için kullanılan bir method
    {
        var dbSet = await GetDbSetAsync(); //veritabanı tablosuna eriştim
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                author => author.Name.Contains(filter) //Eğer filter boş değilse, author.Name içinde bu değeri içerenleri seçiyor.
            )
            .OrderBy(sorting) //Kayıtları sorting parametresine göre sıralıyor. Örneğin, sorting = "Name desc" dersek isimleri tersten sıralar.
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();//Sonuçları List<Author> olarak döndürür.
    }
    
}