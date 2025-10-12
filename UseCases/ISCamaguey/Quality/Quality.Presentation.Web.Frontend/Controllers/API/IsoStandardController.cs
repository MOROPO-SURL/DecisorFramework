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
    public class IsoStandardController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<IsoStandard, int, IsoStandardInputModel, IsoStandardDisplayModel, IsoStandardFilterModel>
    {
        public IsoStandardController(IEntityRepository<IsoStandard, int> repository, IStringLocalizer localizer, ILogger<IsoStandardController> logger) : base(repository, localizer, logger)
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

        public override ActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}
