using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API;

[Route("api/servicing/[controller]")]
[ApiController]
public class LegalClientSampleAnalysisServiceExecutionsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<LegalClientSampleAnalysisServiceExecution, System.Guid, LegalClientSampleAnalysisServiceExecutionInputModel, LegalClientSampleAnalysisServiceExecutionDisplayModel, LegalClientSampleAnalysisServiceExecutionFilterModel>
{
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;
    private readonly IEntityRepository<LegalClientSampleAnalysisServiceOrder, long> orderRepository;

    public LegalClientSampleAnalysisServiceExecutionsController(IEntityRepository<LegalClientSampleAnalysisServiceOrder, long> orderRepository, IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<LegalClientSampleAnalysisServiceExecution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientSampleAnalysisServiceExecutionsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientSampleAnalysisServiceExecutionsController> logger) : base(repository, localizer, logger)
    {
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
        this.orderRepository = orderRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<LegalClientSampleAnalysisServiceExecution, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<LegalClientSampleAnalysisServiceExecution, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    protected override LegalClientSampleAnalysisServiceExecutionDisplayModel EntityToDisplayModel(LegalClientSampleAnalysisServiceExecution entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Order.Contract.Client.Contact.Identity.Image != null)
        {
            model.Order.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Order.Contract.Client.Contact.Identity.Image.ContentType);
        }

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PreCreate(LegalClientSampleAnalysisServiceExecution entity, LegalClientSampleAnalysisServiceExecutionInputModel model)
    {
        base.PreCreate(entity, model);

        var order = orderRepository.Get(entity.OrderId);

        order.ExecutedAt = System.DateTime.Now;

        orderRepository.Update(order, User.Identity.Name, false);

        entity.Document = documentRepository.Add(new Document
        {
            ContentType = model.Document.ContentType,
            Length = model.Document.ContentData.LongLength,
            Name = model.Document.Name,
            Description = model.Document.Description
        }, User.Identity.Name, false);

        documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);
    }

    protected override void PreEdit(LegalClientSampleAnalysisServiceExecution entity, LegalClientSampleAnalysisServiceExecutionInputModel model)
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