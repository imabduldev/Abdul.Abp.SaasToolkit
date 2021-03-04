using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.TenantManagement
{
    public class EditionManager : DomainService, IEditionManager
    {
        protected IEditionRepository EditionRepository { get; }

        public EditionManager(IEditionRepository editionRepository)
        {
            EditionRepository = editionRepository;

        }

        public virtual async Task ChangeNameAsync(Edition edition, string displayName)
        {
            Check.NotNull(edition, nameof(edition));
            Check.NotNull(displayName, nameof(displayName));
            await ValidateNameAsync(displayName, edition.Id);
            edition.SetDisplayName(displayName);
        }

        public virtual async Task<Edition> CreateAsync(string displayName)
        {
            Check.NotNull(displayName, nameof(displayName));
            await ValidateNameAsync(displayName);
            return new Edition(GuidGenerator.Create(), displayName);

        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            var edition = await EditionRepository.FindByNameAsync(name);
            if (edition != null && edition.Id != expectedId)
            {
                throw new UserFriendlyException("Duplicate edition name: " + name);
            }
        }
    }
}