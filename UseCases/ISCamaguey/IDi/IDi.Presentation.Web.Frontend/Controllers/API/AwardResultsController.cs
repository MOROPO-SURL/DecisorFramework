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
public class AwardResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<AwardResult, System.Guid, AwardResultInputModel, AwardResultDisplayModel, AwardResultFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public AwardResultsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<AwardResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AwardResultsController> localizer, Microsoft.Extensions.Logging.ILogger<AwardResultsController> logger)
        : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<AwardResult, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<AwardResult, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override AwardResultDisplayModel EntityToDisplayModel(AwardResult entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.Receptor.Contact.Identity.Image != null)
        {
            model.Receptor.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Receptor.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PostCreate(AwardResult entity, AwardResultInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(AwardResult entity, AwardResultInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}