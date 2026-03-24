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
public class NamingResolutionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NamingResolution, System.Guid, NamingResolutionInputModel, NamingResolutionDisplayModel, NamingResolutionFilterModel>
{
    private readonly IEntityRepository<AdmitionPropousal, System.Guid> admitionPropousalRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public NamingResolutionsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<AdmitionPropousal, System.Guid> admitionPropousalRepository, IEntityRepository<NamingResolution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NamingResolutionsController> localizer, Microsoft.Extensions.Logging.ILogger<NamingResolutionsController> logger) : base(repository, localizer, logger)
    {
        this.admitionPropousalRepository = admitionPropousalRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<NamingResolution, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<NamingResolution, object> GetOrderSelector()
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

    protected override NamingResolutionDisplayModel EntityToDisplayModel(NamingResolution entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.AdmitionPropousal != null && model.AdmitionPropousal.Candidate.Postulation.Contact.Identity.Image != null)
        {
            model.AdmitionPropousal.Candidate.Postulation.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.AdmitionPropousal.OcupationCandidate.Postulation.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PreCreate(NamingResolution entity, NamingResolutionInputModel model)
    {
        base.PreCreate(entity, model);

        var _entity = admitionPropousalRepository.Get(model.AdmitionPropousalId);

        _entity.Archived = true;

        admitionPropousalRepository.Update(_entity, User.Identity.Name, false);
    }

    protected override void PostCreate(NamingResolution entity, NamingResolutionInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PreEdit(NamingResolution entity, NamingResolutionInputModel model)
    {
        base.PreEdit(entity, model);

        // TODO Improbe validation by find resolution id in NamingEmploymentContract !!!
        if (entity.ConcretedAt != null) throw new Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Resolution concreted");

        if (entity.AdmitionPropousalId != model.AdmitionPropousalId)
        {
            var outEntity = admitionPropousalRepository.Get(model.AdmitionPropousalId);

            outEntity.Archived = false;

            admitionPropousalRepository.Update(outEntity, User.Identity.Name, false);

            entity.AdmitionPropousal = null;
            entity.AdmitionPropousalId = model.AdmitionPropousalId;

            var inEntity = admitionPropousalRepository.Get(model.AdmitionPropousalId);

            inEntity.Archived = true;

            admitionPropousalRepository.Update(inEntity, User.Identity.Name, false);
        }
    }

    protected override void PostEdit(NamingResolution entity, NamingResolutionInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
