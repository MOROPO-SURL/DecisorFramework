using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("Quality")]
public class IsoStandardsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<IsoStandard, System.Guid, IsoStandardInputModel, IsoStandardDisplayViewModel>
{
    public IsoStandardsController(IEntityRepository<IsoStandard, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<IsoStandardsController> localizer, ILogger<IsoStandardsController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.IsoStandardViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(IsoStandardInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(IsoStandardInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.IsoStandardEditorPermission)]
    public override IActionResult Enable(System.Guid key)
    {
        return base.Enable(key);
    }

    [RequirePermissions(Authorization.IsoStandardEditorPermission)]
    public override IActionResult Disable(System.Guid key)
    {
        return base.Disable(key);
    }

    [RequirePermissions(Authorization.IsoStandardEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.IsoStandardEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.IsoStandardRemoverPermission)]
    public override IActionResult Delete(IsoStandardDisplayViewModel model)
    {
        return base.Delete(model);
    }
}