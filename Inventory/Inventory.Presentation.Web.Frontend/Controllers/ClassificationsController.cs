using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/inventory/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class ClassificationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<Classification, System.Guid, ClassificationDisplayModel, ClassificationFilterModel>
{
    public ClassificationsController(Guama.Core.Persistence.Repositories.IEntityRepository<Classification, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ClassificationsController> localizer, Microsoft.Extensions.Logging.ILogger<ClassificationsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Classification, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Classification, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
