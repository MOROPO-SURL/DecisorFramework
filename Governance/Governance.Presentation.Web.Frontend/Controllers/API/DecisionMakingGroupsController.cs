using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/governance/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class DecisionMakingGroupsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<DecisionMakingGroup, System.Guid, DecisionMakingGroupInputModel, DecisionMakingGroupDisplayModel>
    {
        public DecisionMakingGroupsController(IEntityRepository<DecisionMakingGroup, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<DecisionMakingGroupsController> localizer, ILogger<DecisionMakingGroupsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<DecisionMakingGroup, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<DecisionMakingGroup, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override DecisionMakingGroupDisplayModel EntityToDisplayModel(DecisionMakingGroup entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Leader.Contact.Identity.Image != null)
            {
                model.Leader.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leader.Contact.Identity.Image.ContentType);
            }

            model.Members = entity.EmployeeBridges.Select(bridge =>
            {
                var _model = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Contact.Identity.Image != null)
                {
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
                }

                return _model;
            }).ToArray();

            model.Collaborators = entity.ContactBridges.Select(bridge =>
            {
                var _model = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Identity.Image != null)
                {
                    _model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
                }

                return _model;
            }).ToArray();

            return model;
        }
    }
}
