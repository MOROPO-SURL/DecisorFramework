using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

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
    }
}
