using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;

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
    }
}
