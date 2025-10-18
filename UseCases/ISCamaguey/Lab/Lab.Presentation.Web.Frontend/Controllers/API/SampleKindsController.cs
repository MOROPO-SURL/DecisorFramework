using Microsoft.AspNetCore.Mvc;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/lab/[controller]")]
    [ApiController]
    public class SampleKindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<SampleKind, System.Guid, SampleKindDisplayModel, SampleKindFilterModel>
    {
        public SampleKindsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<SampleKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SampleKindsController> localizer, Microsoft.Extensions.Logging.ILogger<SampleKindsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<SampleKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<SampleKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}