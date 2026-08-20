using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("domain")]
public class AdministrativeEntityKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<AdministrativeEntityKind, System.Guid, AdministrativeEntityKindInputViewModel, AdministrativeEntityKindDisplayViewModel>
{
    public AdministrativeEntityKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<AdministrativeEntityKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AdministrativeEntityKindsController> localizer, Microsoft.Extensions.Logging.ILogger<AdministrativeEntityKindsController> logger) : base(repository, localizer, logger)
    {
    }
}