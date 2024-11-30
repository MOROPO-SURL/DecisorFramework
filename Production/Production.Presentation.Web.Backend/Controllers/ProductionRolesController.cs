using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("production")]
    public class ProductionRolesController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<ProductionRole, Guid, ProductionRoleInputViewModel, ProductionRoleDisplayViewModel>
    {
        public ProductionRolesController(Guama.Core.Persistence.Repositories.IEntityRepository<ProductionRole, Guid> repository, IStringLocalizer<ProductionRolesController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionRolesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleCreatorPermission)]
        public override IActionResult Create(ProductionRoleInputViewModel model)
        {
            return base.Create(model);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Edit(ProductionRoleInputViewModel model)
        {
            return base.Edit(model);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Enable(Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Disable(Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Archive(Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleEditorPermission)]
        public override IActionResult Unarchive(Guid key)
        {
            return base.Unarchive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleRemoverPermission)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRoleRemoverPermission)]
        public override IActionResult Delete(ProductionRoleDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
