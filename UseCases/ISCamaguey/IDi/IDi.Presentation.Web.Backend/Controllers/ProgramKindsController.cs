using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Input;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("IDi")]
public class ProgramKindsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<ProgramKind, System.Guid, ProgramKindInputViewModel, ProgramKindDisplayViewModel>
{
    public ProgramKindsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ProgramKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProgramKindsController> localizer, Microsoft.Extensions.Logging.ILogger<ProgramKindsController> logger) : base(repository, localizer, logger)
    {
    }
}