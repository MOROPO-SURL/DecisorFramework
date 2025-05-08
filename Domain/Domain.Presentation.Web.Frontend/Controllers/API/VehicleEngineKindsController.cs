namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VehicleEngineKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<Persistence.Entities.VehicleEngineKind, System.Guid, Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel>
    {
        public VehicleEngineKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.VehicleEngineKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleEngineKindsController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleEngineKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.VehicleEngineKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Persistence.Entities.VehicleEngineKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
