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
    public class EditModalModel : TenantManagementPageModel
    {
        [BindProperty]
        public TenantInfoModel Tenant { get; set; }
        public List<SelectListItem> Editions { get; set; }

        protected ITenantAppService TenantAppService { get; }
        protected IEditionAppService EditionAppService { get; }

        public EditModalModel(ITenantAppService tenantAppService,
                              IEditionAppService editionAppService)
        {
            TenantAppService = tenantAppService;
            EditionAppService = editionAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid id)
        {
            var editionLookup = await EditionAppService.GetEditionLookupAsync();
            Editions = editionLookup.Items
                .Select(x => new SelectListItem(x.DisplayName, x.Id.ToString()))
                .ToList();

            Tenant = ObjectMapper.Map<TenantDto, TenantInfoModel>(
                await TenantAppService.GetAsync(id)
            );

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<TenantInfoModel, TenantUpdateDto>(Tenant);
            await TenantAppService.UpdateAsync(Tenant.Id, input);

            return NoContent();
        }

        public class TenantInfoModel : ExtensibleObject
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Editions))]
            [Display(Name = "DisplayName:EditionName")]
            public Guid? EditionId { get; set; }

            [Required]
            [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]
            [Display(Name = "DisplayName:TenantName")]
            public string Name { get; set; }
        }
    }
}