using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NamingEmploymentContractsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<NamingEmploymentContract, int, NamingEmploymentContractDisplayModel, NamingEmploymentContractFilterModel>
    {
        public NamingEmploymentContractsController(Guama.Core.Persistence.Repositories.IEntityRepository<NamingEmploymentContract, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<NamingEmploymentContractsController> localizer, Microsoft.Extensions.Logging.ILogger<NamingEmploymentContractsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<NamingEmploymentContract, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NamingEmploymentContract, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }
    }
}
