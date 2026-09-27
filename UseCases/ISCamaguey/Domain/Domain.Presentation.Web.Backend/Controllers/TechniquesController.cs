using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class TechniquesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Technique, System.Guid, TechniqueInputModel, TechniqueDisplayViewModel>
    {
        public TechniquesController( IEntityRepository<Technique, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TechniquesController> localizer, ILogger<TechniquesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.TechniqueViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(TechniqueInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(TechniqueInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.TechniqueEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.TechniqueEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.TechniqueEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.TechniqueEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.TechniqueRemoverPermission)]
        public override IActionResult Delete(TechniqueDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
