using AutoMapper;
using Volo.Abp.TenantManagement.Web.Pages.TenantManagement.Tenants;

namespace Volo.Abp.TenantManagement.Web
{
    public class AbpTenantManagementWebAutoMapperProfile : Profile
    {
        public AbpTenantManagementWebAutoMapperProfile()
        {
            //Edition
            //List
            CreateMap<EditionDto, Pages.TenantManagement.Editions.EditModalModel.EditionInfoModel>();

            //CreateModal
            CreateMap<Pages.TenantManagement.Editions.CreateModalModel.EditionInfoModel, EditionCreateDto>().MapExtraProperties();

            //EditModal
            CreateMap<Pages.TenantManagement.Editions.EditModalModel.EditionInfoModel, EditionUpdateDto>().MapExtraProperties();

            //Tenant
            //List
            CreateMap<TenantDto, EditModalModel.TenantInfoModel>();

            //CreateModal
            CreateMap<CreateModalModel.TenantInfoModel, TenantCreateDto>()
                .MapExtraProperties();

            //EditModal
            CreateMap<EditModalModel.TenantInfoModel, TenantUpdateDto>()
                .MapExtraProperties();
        }
    }
}
