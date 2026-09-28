using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ThesisResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ThesisResult, System.Guid, ThesisResultInputModel, ThesisResultDisplayModel, ThesisResultFilterModel>
{
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;

    public ThesisResultsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<ThesisResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ThesisResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ThesisResultsController> logger)
        : base(repository, localizer, logger)
    {
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ThesisResult, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<ThesisResult, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ThesisResultDisplayModel EntityToDisplayModel(ThesisResult entity)
    {
        var model = base.EntityToDisplayModel(entity);

        model.InternalResearchers = [.. entity.InternalResearcherBridges.Select(bridge =>
        {
            InternalResearcherDisplayModel _model = new();

            _model.Import(bridge.Stern);

            if (_model.Employee.Contact.Identity.Image != null)
            {
                _model.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Employee.Contact.Identity.Image.ContentType);
            }

            return _model;
        })];

        model.ExternalResearchers = [.. entity.ExternalResearcherBridges.Select(bridge =>
        {
            ExternalResearcherDisplayModel _model = new();

            _model.Import(bridge.Stern);

            if (_model.Contact.Identity.Image != null)
            {
                _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
            }

            return _model;
        })];

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    protected override void PreCreate(ThesisResult entity, ThesisResultInputModel model)
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
    }

    protected override void PreEdit(ThesisResult entity, ThesisResultInputModel model)
    {
        base.PreEdit(entity, model);

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
