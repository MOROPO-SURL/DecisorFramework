namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class WorkPositionKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.WorkPositionKind, System.Guid, Interop.API.Common.Models.Display.WorkPositionKindDisplayModel>
    {
        public WorkPositionKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.WorkPositionKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkPositionKindsController> localizer, Microsoft.Extensions.Logging.ILogger<WorkPositionKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.WorkPositionKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.WorkPositionKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
