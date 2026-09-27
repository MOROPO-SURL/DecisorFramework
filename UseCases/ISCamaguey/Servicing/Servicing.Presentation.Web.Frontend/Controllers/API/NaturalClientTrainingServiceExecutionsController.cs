using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API;

[Route("api/servicing/[controller]")]
[ApiController]
public class NaturalClientTrainingServiceExecutionsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NaturalClientTrainingServiceExecution, System.Guid, NaturalClientTrainingServiceExecutionInputModel, NaturalClientTrainingServiceExecutionDisplayModel, NaturalClientTrainingServiceExecutionFilterModel>
{
    public NaturalClientTrainingServiceExecutionsController(IEntityRepository<NaturalClientTrainingServiceExecution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientTrainingServiceExecutionsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientTrainingServiceExecutionsController> logger) : base(repository, localizer, logger)
    {
    }
    protected override System.Linq.Expressions.Expression<System.Func<NaturalClientTrainingServiceExecution, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<NaturalClientTrainingServiceExecution, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    protected override NaturalClientTrainingServiceExecutionDisplayModel EntityToDisplayModel(NaturalClientTrainingServiceExecution entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Order.Contract.Client.Contact.Identity.Image != null)
        {
            model.Order.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Order.Contract.Client.Contact.Identity.Image.ContentType);
        }

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }
}