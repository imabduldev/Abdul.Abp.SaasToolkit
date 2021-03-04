# Abdul Saas Toolkit
ABP Saas Toolkit. Create and manage editions and tenants and assign features to any edition. Assign edition or indivual feature to any tenant.

### How To?

1. Create multi tenant project from abp application template
2. Remove the following packages from your solution
   1. Volo.Abp.TenantManagement.Application
   2. Volo.Abp.TenantManagement.Application.Contracts
   3. Volo.Abp.TenantManagement.Domain
   4. Volo.Abp.TenantManagement.Domain.Shared
   5. Volo.Abp.TenantManagement.EntityFrameworkCore
   6. Volo.Abp.TenantManagement.HttpApi
   7. Volo.Abp.TenantManagement.HttpApi.Client
   8. Volo.Abp.TenantManagement.Web
3. Install following packages respectively from nuget package manager according to the above packages
   1. [Abdul.Abp.SaasToolkit.Application](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.Application/)
   2. [Abdul.Abp.SaasToolkit.Application.Contracts](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.Application.Contracts/)
   3. [Abdul.Abp.SaasToolkit.Domain](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.Domain/)
   4. [Abdul.Abp.SaasToolkit.Domain.Shared](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.Domain.Shared/)
   5. [Abdul.Abp.SaasToolkit.EntityFrameworkCore](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.EntityFrameworkCore/)
   6. [Abdul.Abp.SaasToolkit.HttpApi](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.HttpApi/)
   7. [Abdul.Abp.SaasToolkit.HttpApi.Client](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.HttpApi.Client/)
   8. [Abdul.Abp.SaasToolkit.Web](https://www.nuget.org/packages/Abdul.Abp.SaasToolkit.Web/)
4. Have fun! nothing to do more.

### Note

Angular and React are not supported.  MongoDB and Blazor packages will be added soon.

