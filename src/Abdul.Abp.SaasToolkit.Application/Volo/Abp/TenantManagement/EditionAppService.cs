using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    [Authorize(TenantManagementPermissions.Editions.Default)]
    public class EditionAppService : TenantManagementAppServiceBase, IEditionAppService
    {
        protected IEditionRepository EditionRepository { get; }
        protected IEditionManager EditionManager { get; }


        public EditionAppService(
            IEditionRepository editionRepository,
            IEditionManager editionManager)
        {
            EditionRepository = editionRepository;
            EditionManager = editionManager;
        }

        [Authorize(TenantManagementPermissions.Editions.Create)]
        public async Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            var edition = await EditionManager.CreateAsync(input.DisplayName);
            await EditionRepository.InsertAsync(edition);
            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }
        [Authorize(TenantManagementPermissions.Editions.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            var edition = await EditionRepository.FindAsync(id);
            if (edition == null)
            {
                return;
            }

            await EditionRepository.DeleteAsync(edition);
        }

        public async Task<ListResultDto<EditionLookupDto>> GetEditionLookupAsync()
        {
            var editions = await EditionRepository.GetListAsync();

            return new ListResultDto<EditionLookupDto>(
                ObjectMapper.Map<List<Edition>, List<EditionLookupDto>>(editions)
            );
        }

        public async Task<EditionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Edition, EditionDto>(
               await EditionRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            var count = await EditionRepository.GetCountAsync(input.Filter);
            var list = await EditionRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<EditionDto>(
                count,
                ObjectMapper.Map<List<Edition>, List<EditionDto>>(list)
            );
        }

        [Authorize(TenantManagementPermissions.Editions.Update)]
        public async Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            var edition = await EditionRepository.GetAsync(id);
            await EditionManager.ChangeNameAsync(edition, input.DisplayName);
            await EditionRepository.UpdateAsync(edition);
            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }
    }
}