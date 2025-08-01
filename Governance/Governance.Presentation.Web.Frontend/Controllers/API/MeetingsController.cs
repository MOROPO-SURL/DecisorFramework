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
    public class MeetingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Meeting, System.Guid, MeetingInputModel, MeetingDisplayModel>
    {
        public MeetingsController(IEntityRepository<Meeting, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<MeetingsController> localizer, ILogger<MeetingsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Meeting, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Meeting, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override MeetingDisplayModel EntityToDisplayModel(Meeting entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            model.InternalInvitations = entity.EmployeeBridges.Select(bridge =>
            {
                var _model = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Contact.Identity.Image != null)
                {
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
                }

                return _model;
            }).ToArray();

            model.ExternalInvitations = entity.ContactBridges.Select(bridge =>
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