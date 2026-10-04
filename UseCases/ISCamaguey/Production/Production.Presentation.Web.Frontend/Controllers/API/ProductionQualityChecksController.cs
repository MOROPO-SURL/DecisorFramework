using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/production/[controller]")]
[ApiController]
public sealed class ProductionQualityChecksController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ProductionQualityCheck, System.Guid, ProductionQualityCheckInputModel, ProductionQualityCheckDisplayModel, ProductionQualityCheckFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public ProductionQualityChecksController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<ProductionQualityCheck, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionQualityChecksController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionQualityChecksController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ProductionQualityCheck, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<ProductionQualityCheck, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ProductionQualityCheckDisplayModel EntityToDisplayModel(ProductionQualityCheck entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Author.Contact.Identity.Image != null)
        {
            model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PostCreate(ProductionQualityCheck entity, ProductionQualityCheckInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(ProductionQualityCheck entity, ProductionQualityCheckInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}