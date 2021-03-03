using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class EditionLookupDto : EntityDto<Guid>
    {
        public string DisplayName { get; set; }
    }
}