using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/governance/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class MeetingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<Meeting, System.Guid, MeetingInputModel, MeetingDisplayModel>
    {
        public MeetingsController(IEntityRepository<Meeting, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<MeetingsController> localizer, ILogger<MeetingsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Func<Meeting, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }
    }
}