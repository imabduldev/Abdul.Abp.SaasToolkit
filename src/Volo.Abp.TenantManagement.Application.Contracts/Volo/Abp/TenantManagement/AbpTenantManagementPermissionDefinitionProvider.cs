using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.Abp.TenantManagement
{
    public class AbpTenantManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var tenantManagementGroup = context.AddGroup(TenantManagementPermissions.GroupName, L("Permission:Saas"));

            var tenantsPermission = tenantManagementGroup.AddPermission(TenantManagementPermissions.Tenants.Default, L("Permission:TenantManagement"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Create, L("Permission:Create"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Update, L("Permission:Edit"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Delete, L("Permission:Delete"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.ManageFeatures, L("Permission:ManageFeatures"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.ManageConnectionStrings, L("Permission:ManageConnectionStrings"), multiTenancySide: MultiTenancySides.Host);

            var editionsPermission = tenantManagementGroup.AddPermission(TenantManagementPermissions.Editions.Default, L("Permission:EditionManagement"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(TenantManagementPermissions.Editions.Create, L("Permission:Create"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(TenantManagementPermissions.Editions.Update, L("Permission:Edit"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(TenantManagementPermissions.Editions.Delete, L("Permission:Delete"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(TenantManagementPermissions.Editions.ManageFeatures, L("Permission:ManageFeatures"), multiTenancySide: MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpTenantManagementResource>(name);
        }
    }
}
