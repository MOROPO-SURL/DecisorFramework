using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Route("api/lab/[controller]")]
[ApiController]
public sealed class AnalysesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Analysis, System.Guid, AnalysisInputModel, AnalysisDisplayModel>
{
    private readonly IEntityRepository<AbstractSample, System.Guid> sampleRepository;

    public AnalysesController(IEntityRepository<AbstractSample, System.Guid> sampleRepository, IEntityRepository<Analysis, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AnalysesController> localizer, Microsoft.Extensions.Logging.ILogger<AnalysesController> logger) : base(repository, localizer, logger)
    {
        this.sampleRepository = sampleRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Analysis, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Analysis, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

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
}
