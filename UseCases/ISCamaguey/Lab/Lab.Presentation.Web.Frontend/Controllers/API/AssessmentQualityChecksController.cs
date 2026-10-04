using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/lab/[controller]")]
[ApiController]
public sealed class AssessmentQualityChecksController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<AssessmentQualityCheck, System.Guid, AssessmentQualityCheckInputModel, AssessmentQualityCheckDisplayModel, AssessmentQualityCheckFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public AssessmentQualityChecksController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<AssessmentQualityCheck, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AssessmentQualityChecksController> localizer, Microsoft.Extensions.Logging.ILogger<AssessmentQualityChecksController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<AssessmentQualityCheck, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<AssessmentQualityCheck, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override AssessmentQualityCheckDisplayModel EntityToDisplayModel(AssessmentQualityCheck entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Author.Contact.Identity.Image != null)
        {
            model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PostCreate(AssessmentQualityCheck entity, AssessmentQualityCheckInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(AssessmentQualityCheck entity, AssessmentQualityCheckInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}