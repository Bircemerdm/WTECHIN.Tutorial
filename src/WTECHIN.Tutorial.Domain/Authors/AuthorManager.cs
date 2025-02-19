using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;


namespace WTECHIN.Tutorial.Authors;

public class AuthorManager : DomainService
{
    //ChangeName ve author constructor methodları internal olduğu için bu nedenle sadece domain katmanında kullanılabilecekler
    private readonly IAuthorRepository _authorRepository; //Crud işlemlerini yapmak için gerekli

    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Author> CreateAsync( //yeni bir yazar oluşturmak için gerekli
        string name,
        DateTime birthDate,
        string? shortBio = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name)); // abp nini yardımcı methodu 
        var existingAuthor = await _authorRepository.FindByNameAsync(name); //veritabanında name olarak verilen ismi buldu
        if (existingAuthor != null)
        {
            throw new AuthorAlreadyExistsException(name);  //eğer aynı isme sahip bir kişi varsa hata fırlatır
        }

        return new Author(GuidGenerator.Create(), //yeni bir Author nesnesi oluşturur.GuidGenerator.Create() ⇒ Yeni bir Guid üretir.
            name,
            birthDate,
            shortBio);

    }//Yeni nesne döndürülür (veritabanına eklenmez, sadece oluşturulur
    
    public async Task ChangeNameAsync(
        Author author,
        string newName)
    {
        Check.NotNull(author, nameof(author));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingAuthor = await _authorRepository.FindByNameAsync(newName);
        if (existingAuthor != null && existingAuthor.Id != author.Id)
        {
            throw new AuthorAlreadyExistsException(newName);
        }

        author.ChangeName(newName);
    }
    
    
    
}