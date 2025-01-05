using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/production/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ProductionRolesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.ProductionRole, System.Guid, Interop.API.Common.Models.Display.ProductionRoleDisplayModel>
    {
        public ProductionRolesController(IEntityRepository<Persistence.Entities.ProductionRole, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionRolesController> localizer, ILogger<ProductionRolesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProductionRole, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.ProductionRole, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
