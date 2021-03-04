using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.Abp.TenantManagement
{
    public class EditionUpdateDto : ExtensibleObject
    {
        [Required]
        [StringLength(EditionConsts.MaxNameLength)]
        public string DisplayName { get; set; }
    }
}