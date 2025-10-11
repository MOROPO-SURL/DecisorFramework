using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/domain/[controller]")]
    [ApiController]
    public class TechniquesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Technique, System.Guid, TechniqueInputModel, TechniqueDisplayModel, TechniqueFilterModel>
    {
        public TechniquesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Technique, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TechniquesController> localizer, ILogger<TechniquesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Technique, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Technique, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
