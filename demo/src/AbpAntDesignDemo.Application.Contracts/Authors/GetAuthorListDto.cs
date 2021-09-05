using Volo.Abp.Application.Dtos;

namespace AbpAntDesignDemo.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
