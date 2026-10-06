using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Input;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("IDi")]
    public class TeachingCategoriesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<TeachingCategory, System.Guid, TeachingCategoryInputViewModel, TeachingCategoryDisplayViewModel>
    {
        public TeachingCategoriesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<TeachingCategory, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TeachingCategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<TeachingCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.TeachingCategoryViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(TeachingCategoryInputViewModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(TeachingCategoryInputViewModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.TeachingCategoryEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.TeachingCategoryEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.TeachingCategoryEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.TeachingCategoryEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.TeachingCategoryRemoverPermission)]
        public override IActionResult Delete(TeachingCategoryDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
