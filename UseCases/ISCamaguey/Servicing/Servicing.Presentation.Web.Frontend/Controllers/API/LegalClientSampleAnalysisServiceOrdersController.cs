using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API;

[Route("api/servicing/[controller]")]
[ApiController]
public class LegalClientSampleAnalysisServiceOrdersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<LegalClientSampleAnalysisServiceOrder, long, LegalClientSampleAnalysisServiceOrderInputModel, LegalClientSampleAnalysisServiceOrderDisplayModel, LegalClientSampleAnalysisServiceOrderFilterModel>
{
    public LegalClientSampleAnalysisServiceOrdersController(IEntityRepository<LegalClientSampleAnalysisServiceOrder, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientSampleAnalysisServiceOrdersController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientSampleAnalysisServiceOrdersController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<LegalClientSampleAnalysisServiceOrder, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<LegalClientSampleAnalysisServiceOrder, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    protected override LegalClientSampleAnalysisServiceOrderDisplayModel EntityToDisplayModel(LegalClientSampleAnalysisServiceOrder entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Contract.Client.Contact.Identity.Image != null)
        {
            model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    public override ActionResult Delete(long key)
    {
        return NotFound();
    }
}
