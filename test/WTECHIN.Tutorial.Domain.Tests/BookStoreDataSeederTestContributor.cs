using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial
{
   public class BookStoreDataSeederTestContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        public BookStoreDataSeederTestContributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task SeedAsync (DataSeedContext context)
        {
            if(await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }
            await _bookRepository.InsertAsync(
                new Book {
                    Name="1984",
                    Type=BookType.Dystopia,
                    PublishDate=new DateTime(1949,6,8),
                    Price=19.84f

            },autoSave:true);
            await _bookRepository.InsertAsync(
               new Book
               {
                   Name = "1985",
                   Type = BookType.Dystopia,
                   PublishDate = new DateTime(1949, 6, 8),
                   Price = 19.85f

               }, autoSave: true);
        }
    }
    
}
