using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Constants.Security;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("commercial")]
    public class LegalBusinessKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<LegalBusinessKind, Guid, LegalBusinessKindInputViewModel, LegalBusinessKindDisplayViewModel>
    {
        public LegalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalBusinessKind, Guid> repository, IStringLocalizer<LegalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalBusinessKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.LegalBusinessKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Authorization.LegalBusinessKindCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Authorization.LegalBusinessKindCreatorPermission)]
        public override IActionResult Create(LegalBusinessKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Edit(LegalBusinessKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Enable(Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Disable(Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Archive(Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Unarchive(Guid key)
        {
            return base.Unarchive(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindRemoverPermission)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Authorization.LegalBusinessKindRemoverPermission)]
        public override IActionResult Delete(LegalBusinessKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
