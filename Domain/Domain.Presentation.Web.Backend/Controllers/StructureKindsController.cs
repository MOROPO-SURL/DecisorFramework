using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class StructureKindsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<StructureKind, System.Guid, StructureKindInputViewModel, StructureKindDisplayModel>
    {
        public StructureKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<StructureKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<StructureKindsController> localizer, Microsoft.Extensions.Logging.ILogger<StructureKindsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}