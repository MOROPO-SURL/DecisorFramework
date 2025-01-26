using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("HHRR")]
    public class SchoolingsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Schooling, System.Guid, SchoolingInputViewModel, SchoolingDisplayViewModel>
    {
        public SchoolingsController(IEntityRepository<Schooling, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SchoolingsController> localizer, ILogger<SchoolingsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.SchoolingViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Authorization.SchoolingCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Authorization.SchoolingCreatorPermission)]
        public override IActionResult Create(SchoolingInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Edit(SchoolingInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.SchoolingEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.SchoolingRemoverPermission)]
        public override IActionResult Delete(SchoolingDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
