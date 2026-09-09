using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class DesignationEmploymentContractsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<DesignationEmploymentContract, System.Guid, DesignationEmploymentContractDisplayModel, DesignationEmploymentContractFilterModel>
{
    public DesignationEmploymentContractsController(Guama.Core.Persistence.Repositories.IEntityRepository<DesignationEmploymentContract, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<DesignationEmploymentContractsController> localizer, Microsoft.Extensions.Logging.ILogger<DesignationEmploymentContractsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<DesignationEmploymentContract, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<DesignationEmploymentContract, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }
}
