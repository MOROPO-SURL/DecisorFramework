using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class AdmitionEmploymentContractsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<AdmitionEmploymentContract, System.Guid, AdmitionEmploymentContractDisplayModel, AdmitionEmploymentContractFilterModel>
{
    public AdmitionEmploymentContractsController(Guama.Core.Persistence.Repositories.IEntityRepository<AdmitionEmploymentContract, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AdmitionEmploymentContractsController> localizer, Microsoft.Extensions.Logging.ILogger<AdmitionEmploymentContractsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<AdmitionEmploymentContract, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<AdmitionEmploymentContract, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }
}
