using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.API.Controllers.Contract;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using System.Runtime.InteropServices;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/usescase/quality/[controller]")]
    [ApiController]
    public class CubanStandardController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<CubanStandard, int, CubanStandardInputModel, CubanStandardDisplayModel, CubanStandardFilterModel>
    {
        public CubanStandardController(IEntityRepository<CubanStandard, int> repository, IStringLocalizer localizer, ILogger<CubanStandardController> logger) : base(repository, localizer, logger)
        {
        }
        protected override System.Linq.Expressions.Expression<System.Func<CubanStandard, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<CubanStandard, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}
