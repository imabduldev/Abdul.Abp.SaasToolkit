using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.Abp.TenantManagement.Web.Pages.TenantManagement.Editions
{
    public class EditModalModel : TenantManagementPageModel
    {
        [BindProperty]
        public EditionInfoModel Edition { get; set; }

        protected IEditionAppService EditionAppService { get; }

        public EditModalModel(IEditionAppService tenantAppService)
        {
            EditionAppService = tenantAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid id)
        {
            Edition = ObjectMapper.Map<EditionDto, EditionInfoModel>(
                await EditionAppService.GetAsync(id)
            );

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<EditionInfoModel, EditionUpdateDto>(Edition);
            await EditionAppService.UpdateAsync(Edition.Id, input);

            return NoContent();
        }

        public class EditionInfoModel : ExtensibleObject
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [StringLength(EditionConsts.MaxNameLength)]
            [Display(Name = "DisplayName:EditionName")]
            public string DisplayName { get; set; }
        }
    }
}