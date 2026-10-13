using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class PropertyKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<PropertyKind, System.Guid, PropertyKindInputViewModel, PropertyKindDisplayViewModel>
    {
        public PropertyKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<PropertyKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyKindsController> localizer, Microsoft.Extensions.Logging.ILogger<PropertyKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.PropertyKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(PropertyKindInputViewModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(PropertyKindInputViewModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PropertyKindEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.PropertyKindEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.PropertyKindEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.PropertyKindEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PropertyKindRemoverPermission)]
        public override IActionResult Delete(PropertyKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
