using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/lab/[controller]")]
[ApiController]
public sealed class AnalysesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Analysis, System.Guid, AnalysisInputModel, AnalysisDisplayModel, AnalysisFilterModel>
{
    private readonly IEntityRepository<AbstractSample, System.Guid> sampleRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public AnalysesController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<AbstractSample, System.Guid> sampleRepository, IEntityRepository<Analysis, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AnalysesController> localizer, Microsoft.Extensions.Logging.ILogger<AnalysesController> logger) : base(repository, localizer, logger)
    {
        this.sampleRepository = sampleRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Analysis, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Analysis, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override AnalysisDisplayModel EntityToDisplayModel(Analysis entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Author.Contact.Identity.Image != null)
        {
            model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PreCreate(Analysis entity, AnalysisInputModel model)
    {
        base.PreCreate(entity, model);

        AbstractSample sample = sampleRepository.Get(entity.SampleId);

        sample.HandledAt = System.DateTime.Now;

        sampleRepository.Update(sample, User.Identity.Name, false);
    }

    protected override void PostCreate(Analysis entity, AnalysisInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(Analysis entity, AnalysisInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}