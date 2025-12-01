using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Mvc.Route("api/lab/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class SampleReceptionLabelsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIManagementFilteredController<SampleReceptionLabel, System.Guid, SampleReceptionLabelInputModel, SampleReceptionLabelDisplayModel, SampleReceptionLabelFilterModel>
{
    public SampleReceptionLabelsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<SampleReceptionLabel, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SampleReceptionLabelsController> localizer, Microsoft.Extensions.Logging.ILogger<SampleReceptionLabelsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Func<SampleReceptionLabel, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
