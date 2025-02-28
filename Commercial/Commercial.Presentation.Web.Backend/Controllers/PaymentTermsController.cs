using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Input;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("commercial")]
    public class PaymentTermsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<PaymentTerm, System.Guid, PaymentTermViewInputModel, PaymentTermViewDisplayModel>
    {
        public PaymentTermsController(Guama.Core.Persistence.Repositories.IEntityRepository<PaymentTerm, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PaymentTermsController> localizer, Microsoft.Extensions.Logging.ILogger<PaymentTermsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
