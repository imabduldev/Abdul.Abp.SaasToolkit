using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.TenantManagement
{
    public interface IEditionRepository : IBasicRepository<Edition, Guid>
    {
        Task<Edition> FindByNameAsync(
            string name,
            CancellationToken cancellationToken = default);
        Task<List<Edition>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            CancellationToken cancellationToken = default);
        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default);
    }
}