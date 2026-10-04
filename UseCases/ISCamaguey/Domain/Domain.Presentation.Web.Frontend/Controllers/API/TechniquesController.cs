using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/domain/[controller]")]
[ApiController]
public class TechniquesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Technique, System.Guid, TechniqueInputModel, TechniqueDisplayModel, TechniqueFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public TechniquesController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<Technique, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TechniquesController> localizer, ILogger<TechniquesController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Technique, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Technique, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PostCreate(Technique entity, TechniqueInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(Technique entity, TechniqueInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
