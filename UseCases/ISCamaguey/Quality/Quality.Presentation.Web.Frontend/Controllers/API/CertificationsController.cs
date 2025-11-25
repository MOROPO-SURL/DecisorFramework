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
    public class CertificationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Certification, System.Guid, CertificationInputModel, CertificationDisplayModel, CertificationFilterModel>
    {
        public CertificationsController(IEntityRepository<Certification, System.Guid> repository, IStringLocalizer<CertificationsController> localizer, ILogger<CertificationsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Certification, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Certification, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
