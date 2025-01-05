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
    public class VacantKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<VacantKind, System.Guid, VacantKindInputViewModel, VacantKindDisplayViewModel>
    {
        public VacantKindsController(IEntityRepository<VacantKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VacantKindsController> localizer, ILogger<VacantKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.VacantKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Create(VacantKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Edit(VacantKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.VacantKindEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.VacantKindRemoverPermission)]
        public override IActionResult Delete(VacantKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
