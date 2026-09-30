using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Frontend.Controllers.API;

[Route("api/production/[controller]")]
[ApiController]
public sealed class ProductionQualityChecksController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ProductionQualityCheck, System.Guid, ProductionQualityCheckInputModel, ProductionQualityCheckDisplayModel, ProductionQualityCheckFilterModel>
{
    public ProductionQualityChecksController(IEntityRepository<ProductionQualityCheck, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionQualityChecksController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionQualityChecksController> logger) : base(repository, localizer, logger)
    {
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
}