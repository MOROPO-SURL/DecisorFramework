using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/governance/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class MeetingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Meeting, System.Guid, MeetingInputModel, MeetingDisplayModel, MeetingFilterModel>
{
    private readonly IEntityRepository<Agreement, System.Guid> agreementRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public MeetingsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<Agreement, System.Guid> agreementRepository, IEntityRepository<Meeting, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<MeetingsController> localizer, ILogger<MeetingsController> logger) : base(repository, localizer, logger)
    {
        this.agreementRepository = agreementRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Meeting, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Meeting, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    protected override MeetingDisplayModel EntityToDisplayModel(Meeting entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.Author.Identity.Image != null)
        {
            model.Author.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Identity.Image.ContentType);
        }

        model.InternalInvitations = entity.EmployeeBridges.Select(bridge =>
        {
            var _model = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

            _model.Import(bridge.Stern);

            if (bridge.Stern.Contact.Identity.Image != null)
            {
                _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
            }

            return _model;
        }).ToArray();

        model.ExternalInvitations = entity.ContactBridges.Select(bridge =>
        {
            var _model = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

            _model.Import(bridge.Stern);

            if (bridge.Stern.Identity.Image != null)
            {
                _model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
            }

            return _model;
        }).ToArray();

        model.Agreements = agreementRepository.FindBy(_entity => _entity.MeetingId == entity.Id).OrderBy(entity => entity.Index).ToArray().Select(_entity =>
        {
            var _model = new AgreementDisplayModel();

            _model.Import(_entity);

            if (_entity.Responsible != null && _entity.Responsible.Identity.Image != null)
            {
                _model.Responsible.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Responsible.Identity.Image.ContentType);
            }

            return _model;
        }).ToArray();

        return model;
    }

    protected override void PreCreate(Meeting entity, MeetingInputModel model)
    {
        base.PreCreate(entity, model);

        var index = 1;

        foreach (var _model in model.IncomingAgreements)
        {
            var _entity = _model.Export();

            _entity.MeetingId = entity.Id;
            _entity.Index = index++;

            agreementRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PostCreate(Meeting entity, MeetingInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PreEdit(Meeting entity, MeetingInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (var _model in model.OutgoingAgreements)
        {
            agreementRepository.Delete(new Agreement { Id = _model.Id }, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionAgreements)
        {
            var _entity = _model.Export();

            _entity.MeetingId = entity.Id;

            agreementRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingAgreements)
        {
            var _entity = _model.Export();

            _entity.MeetingId = entity.Id;

            agreementRepository.Add(_entity, User.Identity.Name, false);
        }

        var agreements = agreementRepository.FindBy(_entity => _entity.MeetingId == entity.Id).ToArray();

        var index = 1;

        foreach (var agreement in agreements)
        {
            agreement.Index = index++;

            agreementRepository.Update(agreement, User.Identity.Name, false);
        }
    }

    protected override void PostEdit(Meeting entity, MeetingInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}