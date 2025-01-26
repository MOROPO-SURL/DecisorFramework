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
    public class WorkPositionKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<WorkPositionKind, System.Guid, WorkPositionKindInputViewModel, WorkPositionKindDisplayViewModel>
    {
        public WorkPositionKindsController(IEntityRepository<WorkPositionKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkPositionKindsController> localizer, ILogger<WorkPositionKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.WorkPositionKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Create(WorkPositionKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Edit(WorkPositionKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.WorkPositionKindEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.WorkPositionKindRemoverPermission)]
        public override IActionResult Delete(WorkPositionKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
