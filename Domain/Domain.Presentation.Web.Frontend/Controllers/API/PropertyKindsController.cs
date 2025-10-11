namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PropertyKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.PropertyKind, System.Guid, Interop.API.Common.Models.Display.PropertyKindDisplayModel>
    {
        public PropertyKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.PropertyKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyKindsController> localizer, Microsoft.Extensions.Logging.ILogger<PropertyKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.PropertyKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.PropertyKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
