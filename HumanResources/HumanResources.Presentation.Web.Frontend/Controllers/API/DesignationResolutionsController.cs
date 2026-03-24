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
public class DesignationResolutionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<DesignationResolution, System.Guid, DesignationResolutionInputModel, DesignationResolutionDisplayModel, DesignationResolutionFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public DesignationResolutionsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<DesignationResolution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<DesignationResolutionsController> localizer, Microsoft.Extensions.Logging.ILogger<DesignationResolutionsController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<DesignationResolution, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<DesignationResolution, object> GetOrderSelector()
    {
        return entity => 1000 * entity.Index + entity.Year;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override DesignationResolutionDisplayModel EntityToDisplayModel(DesignationResolution entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.Contact != null && model.Contact.Identity.Image != null)
        {
            model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PostCreate(DesignationResolution entity, DesignationResolutionInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(DesignationResolution entity, DesignationResolutionInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
