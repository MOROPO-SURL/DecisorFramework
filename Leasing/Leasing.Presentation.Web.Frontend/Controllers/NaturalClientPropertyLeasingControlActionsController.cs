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
public sealed class NaturalClientPropertyLeasingControlActionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NaturalClientPropertyLeasingControlAction, System.Guid, NaturalClientPropertyLeasingControlActionInputModel, NaturalClientPropertyLeasingControlActionDisplayModel, NaturalClientPropertyLeasingControlActionFilterModel>
{
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public NaturalClientPropertyLeasingControlActionsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<NaturalClientPropertyLeasingControlAction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientPropertyLeasingControlActionsController> localizer, ILogger<NaturalClientPropertyLeasingControlActionsController> logger) : base(repository, localizer, logger)
    {
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<NaturalClientPropertyLeasingControlAction, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<NaturalClientPropertyLeasingControlAction, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override NaturalClientPropertyLeasingControlActionDisplayModel EntityToDisplayModel(NaturalClientPropertyLeasingControlAction entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Leasing.Contract.Client.Contact.Identity.Image != null)
        {
            model.Leasing.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Client.Contact.Identity.Image.ContentType);
        }

        if (entity.Leasing.Contract.Postulation.Offer.Propousal.Property.FeatureImage != null)
        {
            model.Leasing.Contract.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Leasing.Contract.Postulation.Offer.Propousal.Property.FeatureImage.ContentType);
        }

        return model;
    }

    protected override void PostCreate(NaturalClientPropertyLeasingControlAction entity, NaturalClientPropertyLeasingControlActionInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(NaturalClientPropertyLeasingControlAction entity, NaturalClientPropertyLeasingControlActionInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}