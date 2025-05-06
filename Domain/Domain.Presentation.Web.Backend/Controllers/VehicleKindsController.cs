using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class VehicleKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<VehicleKind, System.Guid, VehicleKindInputViewModel, VehicleKindDisplayViewModel>
    {
        public VehicleKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<VehicleKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleKindsController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleKindsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
