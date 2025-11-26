namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Mvc.Route("api/lab/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class SampleAnalysisServiceOrdersController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long, Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel>
{
    public SampleAnalysisServiceOrdersController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<SampleAnalysisServiceOrdersController> localizer, Microsoft.Extensions.Logging.ILogger<SampleAnalysisServiceOrdersController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, bool>> GetGlobalSelector()
    {
        return entity => entity.SampleReceptionAt == null;
    }
}