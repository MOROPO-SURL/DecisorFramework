using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/legal/[controller]")]
    [ApiController]
    public class ClausesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Clause, System.Guid, ClauseInputModel, ClauseDisplayModel>
    {
        public ClausesController(Guama.Core.Persistence.Repositories.IEntityRepository<Clause, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ClausesController> localizer, Microsoft.Extensions.Logging.ILogger<ClausesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Clause, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Clause, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}