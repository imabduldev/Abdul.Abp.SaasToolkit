using AutoMapper;

namespace Volo.Abp.TenantManagement
{
    public class AbpTenantManagementApplicationAutoMapperProfile : Profile
    {
        public AbpTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties()
                .ForMember(t => t.EditionName, option => option.MapFrom(x => x.Edition.DisplayName)); ;

            CreateMap<Edition, EditionDto>().MapExtraProperties();

            CreateMap<Edition, EditionLookupDto>();
        }
    }
}