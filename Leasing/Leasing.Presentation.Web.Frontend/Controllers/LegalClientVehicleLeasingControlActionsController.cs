using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers;

[Route("api/fwrk/leasing/[controller]")]
[ApiController]
public sealed class LegalClientVehicleLeasingControlActionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientVehicleLeasingControlAction, System.Guid, LegalClientVehicleLeasingControlActionInputModel, LegalClientVehicleLeasingControlActionDisplayModel, LegalClientVehicleLeasingControlActionFilterModel>
{
    public LegalClientVehicleLeasingControlActionsController(IEntityRepository<LegalClientVehicleLeasingControlAction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientVehicleLeasingControlActionsController> localizer, ILogger<LegalClientVehicleLeasingControlActionsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasingControlAction, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<LegalClientVehicleLeasingControlAction, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override LegalClientVehicleLeasingControlActionDisplayModel EntityToDisplayModel(LegalClientVehicleLeasingControlAction entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Leasing.Contract.Client.Contact.Identity.Image != null)
        {
            model.Leasing.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Client.Contact.Identity.Image.ContentType);
        }

        if (entity.Leasing.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage != null)
        {
            model.Leasing.Contract.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage.ContentType);
        }

        return model;
    }
}
