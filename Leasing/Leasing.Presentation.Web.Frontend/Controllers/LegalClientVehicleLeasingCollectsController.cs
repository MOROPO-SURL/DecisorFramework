using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/fwrk/leasing/[controller]")]
[ApiController]
public class LegalClientVehicleLeasingCollectsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientVehicleLeasingCollect, System.Guid, LegalClientVehicleLeasingCollectInputModel, LegalClientVehicleLeasingCollectDisplayModel, LegalClientVehicleLeasingCollectFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public LegalClientVehicleLeasingCollectsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<LegalClientVehicleLeasingCollect, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientVehicleLeasingCollectsController> localizer, ILogger<LegalClientVehicleLeasingCollectsController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasingCollect, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override System.Func<LegalClientVehicleLeasingCollect, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    protected override LegalClientVehicleLeasingCollectDisplayModel EntityToDisplayModel(LegalClientVehicleLeasingCollect entity)
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

    protected override void PostCreate(LegalClientVehicleLeasingCollect entity, LegalClientVehicleLeasingCollectInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(LegalClientVehicleLeasingCollect entity, LegalClientVehicleLeasingCollectInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}