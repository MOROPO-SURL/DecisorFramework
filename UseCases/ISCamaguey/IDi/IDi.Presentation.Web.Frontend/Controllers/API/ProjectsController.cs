using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ProjectsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Project, System.Guid, ProjectInputModel, ProjectDisplayModel, ProjectFilterModel>
{
    private readonly IEntityRepository<ProjectSpecificObjective, System.Guid> specificObjectiveRepository;
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;

    public ProjectsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<ProjectSpecificObjective, System.Guid> specificObjectiveRepository, IEntityRepository<Project, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProjectsController> localizer, Microsoft.Extensions.Logging.ILogger<ProjectsController> logger)
        : base(repository, localizer, logger)
    {
        this.specificObjectiveRepository = specificObjectiveRepository;
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Project, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived && entity.Enabled;
    }

    protected override System.Func<Project, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ProjectDisplayModel EntityToDisplayModel(Project entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.Chief.Employee.Contact.Identity.Image != null)
        {
            model.Chief.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Chief.Employee.Contact.Identity.Image.ContentType);
        }

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    protected override void PreCreate(Project entity, ProjectInputModel model)
    {
        base.PreCreate(entity, model);

        entity.Document = documentRepository.Add(new Document
        {
            ContentType = model.Document.ContentType,
            Length = model.Document.ContentData.LongLength,
            Name = model.Document.Name,
            Description = model.Document.Description
        }, User.Identity.Name, false);

        documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);

        foreach (var _model in model.IncomingSpecificObjectives)
        {
            var _entity = _model.Export();

            _entity.ProjectId = entity.Id;

            specificObjectiveRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PreEdit(Project entity, ProjectInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (var _model in model.OutgoingSpecificObjectives)
        {
            specificObjectiveRepository.Delete(new ProjectSpecificObjective { Id = _model.Id }, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionSpecificObjectives)
        {
            var _entity = _model.Export();

            _entity.ProjectId = entity.Id;

            specificObjectiveRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingSpecificObjectives)
        {
            var _entity = _model.Export();

            _entity.ProjectId = entity.Id;

            specificObjectiveRepository.Add(_entity, User.Identity.Name, false);
        }

        if (model.Document != null)
        {
            entity.Document = documentRepository.Add(new Document
            {
                ContentType = model.Document.ContentType,
                Length = model.Document.ContentData.LongLength,
                Name = model.Document.Name,
                Description = model.Document.Description
            }, User.Identity.Name, false);

            documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);
        }
    }
}
