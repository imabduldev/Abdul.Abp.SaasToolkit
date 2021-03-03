using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.TenantManagement
{
    public interface IEditionAppService : ICrudAppService<EditionDto,
        Guid, GetEditionsInput,
        EditionCreateDto,
        EditionUpdateDto>
    {
        Task<ListResultDto<EditionLookupDto>> GetEditionLookupAsync();
    }
}