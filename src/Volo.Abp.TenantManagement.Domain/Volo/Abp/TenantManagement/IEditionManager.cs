using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.TenantManagement
{
    public interface IEditionManager : IDomainService
    {
        [NotNull]
        Task<Edition> CreateAsync([NotNull] string displayName);

        Task ChangeNameAsync([NotNull] Edition edition, [NotNull] string displayName);
    }
}