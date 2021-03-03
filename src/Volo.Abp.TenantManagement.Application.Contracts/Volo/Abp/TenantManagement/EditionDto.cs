using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class EditionDto : ExtensibleEntityDto<Guid>
    {
        public string DisplayName { get; set; }
    }
}