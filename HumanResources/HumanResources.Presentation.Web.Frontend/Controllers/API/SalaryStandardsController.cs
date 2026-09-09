using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class SalaryStandardsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<SalaryStandard, System.Guid, SalaryStandardInputModel, SalaryStandardDisplayModel, SalaryStandardFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public SalaryStandardsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<SalaryStandard, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SalaryStandardsController> localizer, ILogger<SalaryStandardsController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<SalaryStandard, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<SalaryStandard, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PostCreate(SalaryStandard entity, SalaryStandardInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(SalaryStandard entity, SalaryStandardInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
