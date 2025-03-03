using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WTECHIN.Tutorial.Authors;
using WTECHIN.Tutorial.Books;

namespace WTECHIN.Tutorial;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorManager _authorManager;
    
    
    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository, IAuthorRepository authorRepository, AuthorManager authorManager)
    {
        _bookRepository = bookRepository; 
        _authorRepository = authorRepository;
        _authorManager = authorManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        Console.WriteLine("Seeding authors..."); 
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(new Book
                {
                    Name = "The World",
                    Type = BookType.Biography,
                    PublishDate = new DateTime(1980, 5, 12),
                    Price = 20.30f

                },
                autoSave: true
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
        } //AUTHOR verisi ekleme

      
        if (await _authorRepository.GetCountAsync() <= 0)
        {
            await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                )
            );

            await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                ),
                
            autoSave: true
            );
        }
    }
}