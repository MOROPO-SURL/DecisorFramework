using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/leasing/[controller]")]
    [ApiController]
    public class SupervisionGroupsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<SupervisionGroup, System.Guid, SupervisionGroupInputModel, SupervisionGroupDisplayModel>
    {
        public SupervisionGroupsController(IEntityRepository<SupervisionGroup, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SupervisionGroupsController> localizer, ILogger<SupervisionGroupsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<SupervisionGroup, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<SupervisionGroup, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override SupervisionGroupDisplayModel EntityToDisplayModel(SupervisionGroup entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Representative.Contact.Identity.Image != null)
            {
                model.Representative.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Representative.Contact.Identity.Image.ContentType);
            }

            var members = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>();

            foreach (var bridge in entity.EmployeeBridges)
            {
                var _model = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Contact.Identity.Image != null)
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);

                members.Add(_model);
            }

            model.Members = members.ToArray();

            return model;
        }
    }
}
