namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/commercial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PaymentTermsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<Persistence.Entities.PaymentTerm, System.Guid, Interop.API.Common.Models.Display.PaymentTermDisplayModel>
    {
        public PaymentTermsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.PaymentTerm, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PaymentTermsController> localizer, Microsoft.Extensions.Logging.ILogger<PaymentTermsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.PaymentTerm, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Persistence.Entities.PaymentTerm, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}