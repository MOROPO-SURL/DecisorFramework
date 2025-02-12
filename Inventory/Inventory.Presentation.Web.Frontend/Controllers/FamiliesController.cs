using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/inventory/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class FamiliesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Family, int, FamilyInputModel, FamilyDisplayModel>
    {
        public FamiliesController(Guama.Core.Persistence.Repositories.IEntityRepository<Family, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<FamiliesController> localizer, Microsoft.Extensions.Logging.ILogger<FamiliesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Family, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Family, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}

