using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace WTECHIN.Tutorial.Authors;

public interface IAuthorAppService:IApplicationService
{
    Task<AuthorDto>GetAsync(Guid id);
    Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input); //PagedResultDto ABP de önceden tanımlanmış bir DTO ssınıfıdır.
    Task<AuthorDto> CreateAsync(CreateAuthorDto input);
    Task UpdateAsync(Guid id,UpdateAuthorDto input);
    Task DeleteAsync(Guid id);
}