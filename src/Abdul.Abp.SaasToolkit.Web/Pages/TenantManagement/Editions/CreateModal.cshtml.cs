using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement.Localization;

namespace Volo.Abp.TenantManagement.Web.Pages.TenantManagement.Editions
{
    public class CreateModalModel : TenantManagementPageModel
    {
        [BindProperty]
        public EditionInfoModel Edition { get; set; }

        protected IEditionAppService EditionAppService { get; }

        public CreateModalModel(IEditionAppService editionAppService)
        {
            EditionAppService = editionAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Edition = new EditionInfoModel();
            return await Task.FromResult<IActionResult>(Page());
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<EditionInfoModel, EditionCreateDto>(Edition);
            await EditionAppService.CreateAsync(input);

            return NoContent();
        }

        public class EditionInfoModel : ExtensibleObject
        {
            [Required]
            [StringLength(EditionConsts.MaxNameLength)]
            [Display(Name = "DisplayName:EditionName")]
            public string DisplayName { get; set; }
        }
    }
}
