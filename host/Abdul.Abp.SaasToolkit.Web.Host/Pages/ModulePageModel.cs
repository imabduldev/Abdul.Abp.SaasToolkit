using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.TenantManagement.Module.Pages
{
    public abstract class ModulePageModel : AbpPageModel
    {
        protected ModulePageModel()
        {
            LocalizationResourceType = typeof(AbpTenantManagementResource);
        }
    }
}