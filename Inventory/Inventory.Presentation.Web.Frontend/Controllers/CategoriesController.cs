using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/inventory/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CategoriesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Category, int, CategoryInputModel, CategoryDisplayModel>
    {
        public CategoriesController(Guama.Core.Persistence.Repositories.IEntityRepository<Category, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<CategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<CategoriesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Category, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}

