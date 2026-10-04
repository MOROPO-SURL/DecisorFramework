using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/quality/[controller]")]
[ApiController]
public class CertificationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Certification, System.Guid, CertificationInputModel, CertificationDisplayModel, CertificationFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public CertificationsController(IEntityRepository<Certification, System.Guid> repository, IStringLocalizer<CertificationsController> localizer, ILogger<CertificationsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Certification, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Certification, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PostCreate(Certification entity, CertificationInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(Certification entity, CertificationInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}