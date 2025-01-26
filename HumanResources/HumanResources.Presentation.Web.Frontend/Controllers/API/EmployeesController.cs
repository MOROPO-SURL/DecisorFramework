using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class EmployeesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Employee, System.Guid, EmployeeInputModel, EmployeeDisplayModel>
    {
        public EmployeesController(IEntityRepository<Employee, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<EmployeesController> localizer, Microsoft.Extensions.Logging.ILogger<EmployeesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Employee, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Employee, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override EmployeeDisplayModel EntityToDisplayModel(Employee entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
