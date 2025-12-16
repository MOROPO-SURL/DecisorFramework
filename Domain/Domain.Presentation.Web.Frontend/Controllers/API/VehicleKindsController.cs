namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VehicleKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<Persistence.Entities.VehicleKind, System.Guid, Interop.API.Common.Models.Display.VehicleKindDisplayModel>
    {
        public VehicleKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.VehicleKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleKindsController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.VehicleKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Persistence.Entities.VehicleKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
