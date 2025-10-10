using Microsoft.AspNetCore.Mvc;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/case/lab/[controller]")]
    [ApiController]
    public class WorkingGroupsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<WorkingGroup, System.Guid, WorkingGroupInputModel, WorkingGroupDisplayModel, WorkingGroupFilterModel>
    {
        public WorkingGroupsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<WorkingGroup, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkingGroupsController> localizer, Microsoft.Extensions.Logging.ILogger<WorkingGroupsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<WorkingGroup, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<WorkingGroup, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override WorkingGroupDisplayModel EntityToDisplayModel(WorkingGroup entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Chief.Contact.Identity.Image != null)
            {
                model.Chief.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Chief.Contact.Identity.Image.ContentType);
            }

            if (entity.QualitySpecialist.Contact.Identity.Image != null)
            {
                model.QualitySpecialist.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.QualitySpecialist.Contact.Identity.Image.ContentType);
            }

            model.Employees = entity.EmployeeBridges.Where(bridge => bridge.Stern != null).Select(bridge =>
            {
                var model = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                model.Import(bridge.Stern);

                if (model.Contact.Identity.Image != null)
                {
                    model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
                }

                return model;
            }).ToArray();

            return model;
        }
    }
}
