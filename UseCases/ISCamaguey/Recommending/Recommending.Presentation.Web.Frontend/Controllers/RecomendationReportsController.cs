using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Frontend.Controllers;

[Route("api/recommending/[controller]")]
[ApiController]
public class RecomendationReportsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<RecomendationReport, System.Guid, RecomendationReportInputModel, RecomendationReportDisplayModel, RecomendationReportFilterModel>
{
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;

    public RecomendationReportsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<RecomendationReport, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<RecomendationReportsController> localizer, Microsoft.Extensions.Logging.ILogger<RecomendationReportsController> logger)
        : base(repository, localizer, logger)
    {
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<RecomendationReport, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<RecomendationReport, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override RecomendationReportDisplayModel EntityToDisplayModel(RecomendationReport entity)
    {
        var model = base.EntityToDisplayModel(entity);

        model.Authors = [.. entity.EmployeeBridges.Select(bridge =>
        {
            EmployeeDisplayModel _model = new();

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

    protected override void PreCreate(RecomendationReport entity, RecomendationReportInputModel model)
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

    protected override void PreEdit(RecomendationReport entity, RecomendationReportInputModel model)
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
