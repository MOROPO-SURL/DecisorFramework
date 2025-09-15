using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("governance")]
    public class ProyectionsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Proyection, System.Guid, ProyectionInputModel, ProyectionDisplayViewModel>
    {
        public ProyectionsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Proyection, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProyectionsController> localizer, ILogger<ProyectionsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ProyectionInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ProyectionInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionRemoverPermission)]
        public override IActionResult Delete(ProyectionDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
