using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;
using System;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class SampleKindsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<SampleKind, System.Guid, SampleKindInputViewModel, SampleKindDisplayViewModel>
    {
        public SampleKindsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<SampleKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SampleKindsController> localizer, Microsoft.Extensions.Logging.ILogger<SampleKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.SampleKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Authorization.SampleKindCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Authorization.SampleKindCreatorPermission)]
        public override IActionResult Create(SampleKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Edit(SampleKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Enable(Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Disable(Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Archive(Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.SampleKindEditorPermission)]
        public override IActionResult Unarchive(Guid key)
        {
            return base.Unarchive(key);
        }

        [RequirePermissions(Authorization.SampleKindRemoverPermission)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Authorization.SampleKindRemoverPermission)]
        public override IActionResult Delete(SampleKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
