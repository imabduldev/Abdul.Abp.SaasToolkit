using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.TenantManagement.EntityFrameworkCore
{
    public class EfCoreEditionRepository : EfCoreRepository<ITenantManagementDbContext, Edition, Guid>, IEditionRepository
    {
        public EfCoreEditionRepository(IDbContextProvider<ITenantManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public async Task<Edition> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(t => t.DisplayName == name, GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await this
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                ).CountAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Edition>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(Edition.DisplayName))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}