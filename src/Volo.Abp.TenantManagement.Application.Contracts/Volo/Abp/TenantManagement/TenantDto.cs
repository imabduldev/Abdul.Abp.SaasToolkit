using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class TenantDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }

        public string EditionName { get; set; }

        public Guid EditionId { get; set; }
    }
}