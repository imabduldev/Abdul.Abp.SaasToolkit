using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.TenantManagement.Module.EntityFrameworkCore
{
    public class ModuleHttpApiHostMigrationsDbContext : AbpDbContext<ModuleHttpApiHostMigrationsDbContext>
    {
        public ModuleHttpApiHostMigrationsDbContext(DbContextOptions<ModuleHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }
    }
}
