using Microsoft.AspNetCore.Mvc;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Route("api/governance/[controller]")]
    [ApiController]
    public class ObjectivesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Objective, System.Guid, Interop.API.Common.Models.Input.ObjectiveInputModel, Interop.API.Common.Models.Display.ObjectiveDisplayModel>
    {
        public ObjectivesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Objective, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ObjectivesController> localizer, Microsoft.Extensions.Logging.ILogger<ObjectivesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Objective, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Objective, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override ObjectiveDisplayModel EntityToDisplayModel(Objective entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Responsible.Identity.Image != null)
            {
                model.Responsible.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Identity.Image.ContentType);
            }

            return model;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
