using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.TenantManagement
{
    [Controller]
    [RemoteService(Name = TenantManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("multi-tenancy")]
    [Route("api/multi-tenancy/editions")]
    public class EditionController : AbpController, IEditionAppService
    {
        protected IEditionAppService EditionAppService { get; }

        public EditionController(IEditionAppService editionAppService)
        {
            EditionAppService = editionAppService;
        }

        [HttpPost]
        public Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            //ValidateModel();
            return EditionAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return EditionAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("lookup")]
        public Task<ListResultDto<EditionLookupDto>> GetEditionLookupAsync()
        {
            return EditionAppService.GetEditionLookupAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EditionDto> GetAsync(Guid id)
        {
            return EditionAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            return EditionAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            return EditionAppService.UpdateAsync(id, input);
        }
    }
}