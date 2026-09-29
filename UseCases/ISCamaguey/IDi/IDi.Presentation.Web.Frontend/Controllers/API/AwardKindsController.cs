using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class AwardKindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<AwardKind, System.Guid, AwardKindInputModel, AwardKindDisplayModel, AwardKindFilterModel>
{
    public AwardKindsController(IEntityRepository<AwardKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AwardKindsController> localizer, Microsoft.Extensions.Logging.ILogger<AwardKindsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<AwardKind, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<AwardKind, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
