using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository) //constructor oluşturdum
    {
        _bookRepository = bookRepository; //bu kısımda neden constructor kullandık
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(new Book
            {
                Name = "The World",
                Type = BookType.Biography,
                PublishDate = new DateTime(1980, 5, 12),
                Price = 20.30f

            },
            autoSave: true   //bu yapıyı neden kullandık?
        );
            await _bookRepository.InsertAsync(new Book
            {
                Name = "Mathematical Science",
                Type = BookType.Science,
                PublishDate = new DateTime(2002, 7, 28),
                Price = 58.8f
            }, 
            autoSave: true
            );

        }
    }
}   
