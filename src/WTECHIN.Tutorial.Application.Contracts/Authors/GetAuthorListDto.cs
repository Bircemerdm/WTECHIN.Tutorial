using Volo.Abp.Application.Dtos;

namespace WTECHIN.Tutorial.Authors;

public class GetAuthorListDto:PagedAndSortedResultRequestDto
{
   public string? Filter { get; set; } 
}

//PagedAndSortedResultRequestDtostandart sayfalama ve sıralama özelliklerine sahiptir: int MaxResultCount, int SkipCountve string Sorting.