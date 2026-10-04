using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/idi/[controller]")]
[ApiController]
public class ScientificTechnicalResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ScientificTechnicalResult, System.Guid, ScientificTechnicalResultInputModel, ScientificTechnicalResultDisplayModel, ScientificTechnicalResultFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public ScientificTechnicalResultsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<ScientificTechnicalResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ScientificTechnicalResultsController> logger)
        : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResult, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<ScientificTechnicalResult, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PostCreate(ScientificTechnicalResult entity, ScientificTechnicalResultInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(ScientificTechnicalResult entity, ScientificTechnicalResultInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}