using Microsoft.AspNetCore.Mvc;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Route("api/governance/[controller]")]
    [ApiController]
    public class GuidelinesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Guideline, System.Guid, Interop.API.Common.Models.Input.GuidelineInputModel, Interop.API.Common.Models.Display.GuidelineDisplayModel>
    {
        public GuidelinesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Guideline, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<GuidelinesController> localizer, Microsoft.Extensions.Logging.ILogger<GuidelinesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Guideline, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Guideline, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
