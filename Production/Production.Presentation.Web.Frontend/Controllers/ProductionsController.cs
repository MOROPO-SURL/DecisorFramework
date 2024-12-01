using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/production/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ProductionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Persistence.Entities.Production, System.Guid, ProductionInputModel, ProductionDisplayModel>
    {
        public ProductionsController(IEntityRepository<Persistence.Entities.Production, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionsController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Production, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
