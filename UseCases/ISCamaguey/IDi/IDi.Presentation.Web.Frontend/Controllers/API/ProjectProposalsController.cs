using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/idi/[controller]")]
[ApiController]
public class ProjectProposalsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ProjectProposal, System.Guid, ProjectProposalInputModel, ProjectProposalDisplayModel, ProjectProposalFilterModel>
{
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public ProjectProposalsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<ProjectProposal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProjectProposalsController> localizer, Microsoft.Extensions.Logging.ILogger<ProjectProposalsController> logger) : base(repository, localizer, logger)
    {
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ProjectProposal, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<ProjectProposal, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    protected override ProjectProposalDisplayModel EntityToDisplayModel(ProjectProposal entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    protected override void PreCreate(ProjectProposal entity, ProjectProposalInputModel model)
    {
        base.PreCreate(entity, model);

        //foreach (var _model in model.IncomingDocuments)
        //{
        //    var __entity = documentRepository.Add(new Document
        //    {
        //        Id = _model.Id,
        //        Name = _model.Name,
        //        ContentType = _model.ContentType,
        //        Description = _model.Description,
        //        Length = _model.ContentData.Length
        //    }, User.Identity.Name, false);

        //    entity.DocumentBridges.Add(new ProjectProposalDocumentBridge
        //    {
        //        ProwId = entity.Id,
        //        SternId = __entity.Id
        //    });

        //    documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
        //}
    }

    protected override void PreEdit(ProjectProposal entity, ProjectProposalInputModel model)
    {
        base.PreEdit(entity, model);

        //#region Documents

        //foreach (var _model in model.OutgoingDocuments)
        //{
        //    var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

        //    documentRepository.Delete(_entity, User.Identity.Name, false);
        //}

        //foreach (var _model in model.EditionDocuments)
        //{
        //    var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

        //    _model.Mergue(_entity);

        //    documentRepository.Update(_entity, User.Identity.Name, false);
        //}

        //foreach (var _model in model.IncomingDocuments)
        //{
        //    var _entity = documentRepository.Add(new Document
        //    {
        //        Id = _model.Id,
        //        Name = _model.Name,
        //        ContentType = _model.ContentType,
        //        Description = _model.Description,
        //        Length = _model.ContentData.Length
        //    }, User.Identity.Name, false);

        //    entity.DocumentBridges.Add(new ProjectProposalDocumentBridge
        //    {
        //        ProwId = entity.Id,
        //        SternId = _entity.Id
        //    });

        //    documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
        //}

        //#endregion
    }

    protected override void PostCreate(ProjectProposal entity, ProjectProposalInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(ProjectProposal entity, ProjectProposalInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
