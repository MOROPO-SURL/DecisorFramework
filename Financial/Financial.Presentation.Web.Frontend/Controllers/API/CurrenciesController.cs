using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/financial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CurrenciesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<Currency, System.Guid, Interop.API.Common.Models.Input.CurrencyInputModel, Interop.API.Common.Models.Display.CurrencyDisplayModel>
    {
        public CurrenciesController(IEntityRepository<Currency, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CurrenciesController> localizer, ILogger<CurrenciesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Currency, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}
