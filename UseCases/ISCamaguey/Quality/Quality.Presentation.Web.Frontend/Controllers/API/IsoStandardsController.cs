using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.API.Controllers.Contract;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/quality/[controller]")]
    [ApiController]
    public class IsoStandardsController : AbstractArchivableEnableableEntityAPIManagementFilteredController<IsoStandard, System.Guid, IsoStandardInputModel, IsoStandardDisplayModel, IsoStandardFilterModel>
    {
        public IsoStandardsController(IEntityRepository<IsoStandard, System.Guid> repository, IStringLocalizer<IsoStandardsController> localizer, ILogger<IsoStandardsController> logger) : base(repository, localizer, logger)
        {
        }
        protected override System.Linq.Expressions.Expression<System.Func<IsoStandard, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<IsoStandard, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
