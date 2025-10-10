using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/financial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CostCentersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<CostCenter, System.Guid, Interop.API.Common.Models.Input.CostCenterInputModel, Interop.API.Common.Models.Display.CostCenterDisplayModel, Interop.API.Common.Models.Filter.CostCenterFilterModel>
    {
        public CostCentersController(IEntityRepository<CostCenter, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CostCentersController> localizer, ILogger<CostCentersController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<CostCenter, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<CostCenter, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Enable(System.Guid key)
        {
            return NotFound();
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Disable(System.Guid key)
        {
            return NotFound();
        }
    }
}

