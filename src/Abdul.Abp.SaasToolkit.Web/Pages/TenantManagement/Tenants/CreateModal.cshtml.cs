using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Volo.Abp.TenantManagement.Web.Pages.TenantManagement.Tenants
{
    public class CreateModalModel : TenantManagementPageModel
    {
        [BindProperty]
        public TenantInfoModel Tenant { get; set; }
        public List<SelectListItem> Editions { get; set; }

        protected ITenantAppService TenantAppService { get; }
        protected IEditionAppService EditionAppService { get; }

        public CreateModalModel(ITenantAppService tenantAppService,
                                IEditionAppService editionAppService)
        {
            TenantAppService = tenantAppService;
            EditionAppService = editionAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            var editionLookup = await EditionAppService.GetEditionLookupAsync();
            Editions = editionLookup.Items
                .Select(x => new SelectListItem(x.DisplayName, x.Id.ToString()))
                .ToList();

            Tenant = new TenantInfoModel();
            return await Task.FromResult<IActionResult>(Page());
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<TenantInfoModel, TenantCreateDto>(Tenant);
            await TenantAppService.CreateAsync(input);

            return NoContent();
        }

        public class TenantInfoModel: ExtensibleObject
        {
            [Required]
            [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]
            public string Name { get; set; }

            [SelectItems(nameof(Editions))]
            [Display(Name = "DisplayName:EditionName")]
            public Guid? EditionId { get; set; }

            [Required]
            [EmailAddress]
            [MaxLength(256)]
            public string AdminEmailAddress { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MaxLength(128)]
            public string AdminPassword { get; set; }
        }
    }
}
