using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class GetEditionsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}