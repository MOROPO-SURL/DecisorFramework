using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/case/idi/[controller]")]
    [ApiController]
    public class ResearchAreasController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ResearchArea, System.Guid, ResearchAreaInputModel, ResearchAreaDisplayModel, ResearchAreaFilterModel>
    {
        public ResearchAreasController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ResearchArea, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ResearchAreasController> localizer, ILogger<ResearchAreasController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<ResearchArea, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<ResearchArea, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
