using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/inventory/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ClassificationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Classification, System.Guid, ClassificationInputModel, ClassificationDisplayModel>
    {
        public ClassificationsController(Guama.Core.Persistence.Repositories.IEntityRepository<Classification, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ClassificationsController> localizer, Microsoft.Extensions.Logging.ILogger<ClassificationsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Classification, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
