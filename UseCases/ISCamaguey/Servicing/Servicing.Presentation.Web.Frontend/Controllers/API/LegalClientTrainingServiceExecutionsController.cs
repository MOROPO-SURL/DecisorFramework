using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API;

[Route("api/servicing/[controller]")]
[ApiController]
public class LegalClientTrainingServiceExecutionsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientTrainingServiceExecution, System.Guid, LegalClientTrainingServiceExecutionInputModel, LegalClientTrainingServiceExecutionDisplayModel, LegalClientTrainingServiceExecutionFilterModel>
{
    public LegalClientTrainingServiceExecutionsController(IEntityRepository<LegalClientTrainingServiceExecution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientTrainingServiceExecutionsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientTrainingServiceExecutionsController> logger) : base(repository, localizer, logger)
    {
    }
    protected override System.Linq.Expressions.Expression<System.Func<LegalClientTrainingServiceExecution, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<LegalClientTrainingServiceExecution, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    protected override LegalClientTrainingServiceExecutionDisplayModel EntityToDisplayModel(LegalClientTrainingServiceExecution entity)
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