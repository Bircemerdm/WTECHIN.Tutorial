using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using WTECHIN.Tutorial.Permissions;

namespace WTECHIN.Tutorial.Authors;

[Authorize(TutorialPermissions.Authors.Default)]
public class AuthorAppService : TutorialAppService, IAuthorAppService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorManager _authorManager;

    public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
    {
        _authorRepository = authorRepository;
        _authorManager = authorManager;
    }
    
    //service methodlarım bu kısma gelecek
    public async Task<AuthorDto> GetAsync(Guid id) //AuthorDto döndürüyor
    {
        var author= await _authorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author); //veritabanındaki author nesnesini AuthorDto formatına çevirir
    }

    public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Author.Name); //kullanıcı sorting parametresi göndermediyse varsayılan olarak yazar adı alanına göre sıralama yapar
        }
        var authors=await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter); //yazarları getirdim kullanıcının isteğine göre
        var totalCount=input.Filter == null
            ? await _authorRepository.CountAsync()
            : await _authorRepository.CountAsync(
                author => author.Name.Contains(input.Filter));
        return new PagedResultDto<AuthorDto>(
            totalCount,
            ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors) // Yazarları DTO'ya çevir
        );
        
    }

    [Authorize(TutorialPermissions.Authors.Create)]
    public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
    {
        var author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);//authormanager içinde ekstra iş kuralları doğrulamaları var bu yüzden _authormanager ile veritabanına bağlandık
        await _authorRepository.InsertAsync(author); //yeni oluşturduğumuz authoru öğrenci tablosuna ekliyoruz
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }


    [Authorize(TutorialPermissions.Authors.Edit)]
    public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
    {
        var author = await _authorRepository.GetAsync(id);
        if (author.Name != input.Name)
        {
            await _authorManager.ChangeNameAsync(author, input.Name);
        }
        author.BirthDate = input.BirthDate;
        author.ShortBio = input.ShortBio;
        await _authorRepository.UpdateAsync(author); //Güncellenmiş versiyonunu veritabanına kaydediyoruz.
    }
    [Authorize(TutorialPermissions.Authors.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _authorRepository.DeleteAsync(id);
    }
    
}