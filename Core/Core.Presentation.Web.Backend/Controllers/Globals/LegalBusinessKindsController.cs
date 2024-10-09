using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MOROPO.Framework.Decisor.Core.Persistence.Entities;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Controllers.Backend.Global
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("globals")]
    public class LegalBusinessKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<LegalBusinessKind, System.Guid, LegalBusinessKindInputViewModel, LegalBusinessKindDisplayViewModel>
    {
        public LegalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalBusinessKind, System.Guid> repository, IStringLocalizer<LegalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalBusinessKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindCreatorPermission)]
        public override IActionResult Create(LegalBusinessKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Edit(LegalBusinessKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Archive(Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindEditorPermission)]
        public override IActionResult Unarchive(Guid key)
        {
            return base.Unarchive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindRemoverPermission)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalBusinessKindRemoverPermission)]
        public override IActionResult Delete(LegalBusinessKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
