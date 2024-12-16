using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("commercial")]
    public class NaturalBusinessKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<NaturalBusinessKind, Guid, NaturalBusinessKindInputViewModel, NaturalBusinessKindDisplayViewModel>
    {
        public NaturalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<NaturalBusinessKind, Guid> repository, IStringLocalizer<NaturalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalBusinessKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindCreatorPermission)]
        public override IActionResult Create(NaturalBusinessKindInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Edit(NaturalBusinessKindInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Enable(Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Disable(Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Archive(Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindEditorPermission)]
        public override IActionResult Unarchive(Guid key)
        {
            return base.Unarchive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindRemoverPermission)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalBusinessKindRemoverPermission)]
        public override IActionResult Delete(NaturalBusinessKindDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
