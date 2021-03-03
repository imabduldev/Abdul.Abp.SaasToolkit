using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.PageToolbars;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.TenantManagement.Localization;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Pages.TenantManagement.Tenants;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Threading;

namespace Volo.Abp.TenantManagement.Web
{
    [DependsOn(typeof(AbpTenantManagementHttpApiModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
    [DependsOn(typeof(AbpFeatureManagementWebModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class AbpTenantManagementWebModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AbpTenantManagementResource), typeof(AbpTenantManagementWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpTenantManagementWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpTenantManagementWebMainMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpTenantManagementWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpTenantManagementWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpTenantManagementWebAutoMapperProfile>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/TenantManagement/Editions/Index",
                    TenantManagementPermissions.Editions.Default);
                options.Conventions.AuthorizePage("/TenantManagement/Editions/CreateModal",
                    TenantManagementPermissions.Editions.Create);
                options.Conventions.AuthorizePage("/TenantManagement/Editions/EditModal",
                    TenantManagementPermissions.Editions.Update);
                options.Conventions.AuthorizePage("/FeatureManagement/FeatureManagementModal",
                    TenantManagementPermissions.Editions.ManageFeatures);

                options.Conventions.AuthorizePage("/TenantManagement/Tenants/Index",
                    TenantManagementPermissions.Tenants.Default);
                options.Conventions.AuthorizePage("/TenantManagement/Tenants/CreateModal",
                    TenantManagementPermissions.Tenants.Create);
                options.Conventions.AuthorizePage("/TenantManagement/Tenants/EditModal",
                    TenantManagementPermissions.Tenants.Update);
            });

            Configure<AbpPageToolbarOptions>(options =>
            {
                options.Configure<Pages.TenantManagement.Editions.IndexModel>(toolbar =>
                    {
                        toolbar.AddButton(
                            LocalizableString.Create<AbpTenantManagementResource>("NewEdition"),
                            icon: "plus",
                            name: "CreateEdition",
                            requiredPolicyName: TenantManagementPermissions.Editions.Create
                        );
                    }
                );

                options.Configure<IndexModel>(
                    toolbar =>
                    {
                        toolbar.AddButton(
                            LocalizableString.Create<AbpTenantManagementResource>("ManageHostFeatures"),
                            icon: "cog",
                            name: "ManageHostFeatures",
                            requiredPolicyName: FeatureManagementPermissions.ManageHostFeatures
                        );

                        toolbar.AddButton(
                            LocalizableString.Create<AbpTenantManagementResource>("NewTenant"),
                            icon: "plus",
                            name: "CreateTenant",
                            requiredPolicyName: TenantManagementPermissions.Tenants.Create
                        );
                    }
                );
            });
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToUi(
                        TenantManagementModuleExtensionConsts.ModuleName,
                        TenantManagementModuleExtensionConsts.EntityNames.Edition,
                        createFormTypes: new[] { typeof(Pages.TenantManagement.Editions.CreateModalModel.EditionInfoModel) },
                        editFormTypes: new[] { typeof(Pages.TenantManagement.Editions.EditModalModel.EditionInfoModel) }
                    );

                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToUi(
                        TenantManagementModuleExtensionConsts.ModuleName,
                        TenantManagementModuleExtensionConsts.EntityNames.Tenant,
                        createFormTypes: new[] { typeof(CreateModalModel.TenantInfoModel) },
                        editFormTypes: new[] { typeof(EditModalModel.TenantInfoModel) }
                    );
            });
        }
    }
}