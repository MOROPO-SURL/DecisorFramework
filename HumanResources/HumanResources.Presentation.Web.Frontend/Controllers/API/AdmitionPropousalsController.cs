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
public class AdmitionPropousalsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<AdmitionPropousal, System.Guid, AdmitionPropousalInputModel, AdmitionPropousalDisplayModel, AdmitionPropousalFilterModel>
{
    private readonly IEntityRepository<OcupationCandidate, System.Guid> candidateRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public AdmitionPropousalsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<OcupationCandidate, System.Guid> candidateRepository, IEntityRepository<AdmitionPropousal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AdmitionPropousalsController> localizer, ILogger<AdmitionPropousalsController> logger) : base(repository, localizer, logger)
    {
        this.candidateRepository = candidateRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<AdmitionPropousal, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<AdmitionPropousal, object> GetOrderSelector()
    {
        return entity => entity.OcupationCandidate.Postulation.Vacant.Priority;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override AdmitionPropousalDisplayModel EntityToDisplayModel(AdmitionPropousal entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.OcupationCandidate.Postulation.Contact.Identity.Image != null)
        {
            model.Candidate.Postulation.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.OcupationCandidate.Postulation.Contact.Identity.Image.ContentType);
        }

        return model;
    }

    protected override void PreCreate(AdmitionPropousal entity, AdmitionPropousalInputModel model)
    {
        base.PreCreate(entity, model);

        var _entity = candidateRepository.Get(model.CandidateId);

        _entity.Archived = true;

        candidateRepository.Update(_entity, User.Identity.Name, false);
    }

    protected override void PostCreate(AdmitionPropousal entity, AdmitionPropousalInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PreEdit(AdmitionPropousal entity, AdmitionPropousalInputModel model)
    {
        base.PreEdit(entity, model);

        if (entity.OcupationCandidateId != model.CandidateId)
        {
            var oldEntity = candidateRepository.Get(entity.OcupationCandidateId);

            oldEntity.Archived = false;

            candidateRepository.Update(oldEntity, User.Identity.Name, false);

            entity.OcupationCandidate = null;
            entity.OcupationCandidateId = model.CandidateId;

            var newEntity = candidateRepository.Get(model.CandidateId);

            newEntity.Archived = true;

            candidateRepository.Update(newEntity, User.Identity.Name, false);
        }
    }

    protected override void PostEdit(AdmitionPropousal entity, AdmitionPropousalInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
