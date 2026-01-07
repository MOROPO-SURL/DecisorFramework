using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class EmployeesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Employee, System.Guid, EmployeeInputModel, EmployeeDisplayModel, EmployeeFilterModel>
    {
        public EmployeesController(IEntityRepository<Employee, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<EmployeesController> localizer, Microsoft.Extensions.Logging.ILogger<EmployeesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Employee, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Employee, object> GetOrderSelector()
        {
            return entity => entity.Contact.Identity.Name;
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

        [Microsoft.AspNetCore.Mvc.HttpGet("[action]/{key}")]
        public virtual Microsoft.AspNetCore.Mvc.ActionResult<EmployeeDisplayModel> FindByContact(System.Guid key)
        {
            var entity = Repository.FindOneBy(entity => entity.ContactId == key);

            if (entity == null) return NoContent();

            var model = EntityToDisplayModel(entity);

            return Ok(model);
        }
    }
}
