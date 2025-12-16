using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class EmployeeDailyCheckingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<EmployeeDailyChecking, long, EmployeeDailyCheckingInputModel, EmployeeDailyCheckingDisplayModel, EmployeeDailyCheckingFilterModel>
    {
        public EmployeeDailyCheckingsController(Guama.Core.Persistence.Repositories.IEntityRepository<EmployeeDailyChecking, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<EmployeeDailyCheckingsController> localizer, Microsoft.Extensions.Logging.ILogger<EmployeeDailyCheckingsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
