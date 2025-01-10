using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class WorkPositionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<WorkPosition, System.Guid, WorkPositionInputModel, WorkPositionDisplayModel>
    {
        public WorkPositionsController(IEntityRepository<WorkPosition, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkPositionsController> localizer, Microsoft.Extensions.Logging.ILogger<WorkPositionsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<WorkPosition, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
