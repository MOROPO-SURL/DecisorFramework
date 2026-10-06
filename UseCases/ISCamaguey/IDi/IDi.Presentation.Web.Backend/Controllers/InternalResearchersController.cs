using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("IDi")]
    public class InternalResearchersController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<InternalResearcher, System.Guid, InternalResearcherInputModel, InternalResearcherDisplayViewModel>
    {
        public InternalResearchersController(IEntityRepository<InternalResearcher, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<InternalResearchersController> localizer, ILogger<InternalResearchersController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.InternalResearcherViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(InternalResearcherInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(InternalResearcherInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.InternalResearcherEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.InternalResearcherEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.InternalResearcherEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.InternalResearcherEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.InternalResearcherRemoverPermission)]
        public override IActionResult Delete(InternalResearcherDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
