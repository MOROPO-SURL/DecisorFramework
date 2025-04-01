using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VehicleBrandsController : Guama.Core.Presentation.Web.Frontend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Brand, System.Guid, VehicleBrandInputModel, VehicleBrandDisplayModel>
    {
        public VehicleBrandsController(Guama.Core.Persistence.Repositories.IEntityRepository<Brand, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleBrandsController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleBrandsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Brand, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Brand, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
