using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Input;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("IDi")]
public class ProjectCategoriesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<ProjectCategory, System.Guid, ProjectCategoryInputViewModel, ProjectCategoryDisplayViewModel>
{
    public ProjectCategoriesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ProjectCategory, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProjectCategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<ProjectCategoriesController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.ProjectCategoryViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(ProjectCategoryInputViewModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(ProjectCategoryInputViewModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProjectCategoryEditorPermission)]
    public override IActionResult Enable(System.Guid key)
    {
        return base.Enable(key);
    }

    [RequirePermissions(Authorization.ProjectCategoryEditorPermission)]
    public override IActionResult Disable(System.Guid key)
    {
        return base.Disable(key);
    }

    [RequirePermissions(Authorization.ProjectCategoryEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.ProjectCategoryEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProjectCategoryRemoverPermission)]
    public override IActionResult Delete(ProjectCategoryDisplayViewModel model)
    {
        return base.Delete(model);
    }
}