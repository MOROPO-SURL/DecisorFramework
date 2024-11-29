using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/financial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class BankDebitCardsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<BankDebitCard, System.Guid, BankDebitCardInputModel, Interop.API.Common.Models.Display.BankDebitCardDisplayModel>
    {
        private readonly IEntityRepository<BankAccount, System.Guid> bankAccountRepository;

        public BankDebitCardsController(IEntityRepository<BankAccount, System.Guid> bankAccountRepository, IEntityRepository<BankDebitCard, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BankDebitCardsController> localizer, ILogger<BankDebitCardsController> logger) : base(repository, localizer, logger)
        {
            this.bankAccountRepository = bankAccountRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<BankDebitCard, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}
