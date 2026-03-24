using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/financial/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]

public class BankAccountsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<BankAccount, System.Guid, BankAccountInputModel, BankAccountDisplayModel, BankAccountFilterModel>
{
    public BankAccountsController(IEntityRepository<BankAccount, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BankAccountsController> localizer, Microsoft.Extensions.Logging.ILogger<BankAccountsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<BankAccount, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived && entity.Enabled;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }
}
