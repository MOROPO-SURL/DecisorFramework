using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/lab/[controller]")]
[ApiController]
public sealed class AssessmentsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Assessment, System.Guid, AssessmentInputModel, AssessmentDisplayModel>
{
    private readonly IEntityRepository<AbstractSample, System.Guid> sampleRepository;
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;
    private readonly IEntityRepository<AbstractServiceOrder, long> serviceOrderRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public AssessmentsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<AbstractServiceOrder, long> serviceOrderRepository, IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<AbstractSample, System.Guid> sampleRepository, IEntityRepository<Assessment, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AssessmentsController> localizer, Microsoft.Extensions.Logging.ILogger<AssessmentsController> logger) : base(repository, localizer, logger)
    {
        this.sampleRepository = sampleRepository;
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
        this.serviceOrderRepository = serviceOrderRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Assessment, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Assessment, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override AssessmentDisplayModel EntityToDisplayModel(Assessment entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Author.Contact.Identity.Image != null)
        {
            model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
        }

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    protected override void PreCreate(Assessment entity, AssessmentInputModel model)
    {
        base.PreCreate(entity, model);

        AbstractSample sample = sampleRepository.Get(entity.SampleId);

        sample.AssessmentAt = System.DateTime.Now;

        if (sample is ServiceOrderSample serviceOrderSample)
        {
            var serviceOrder = (AbstractSampleAnalysisServiceOrder)serviceOrderRepository.Get(serviceOrderSample.ServiceOrderId);

            serviceOrder.HandledAt = System.DateTime.Now;

            serviceOrderRepository.Update(serviceOrder, User.Identity.Name, false);
        }

        sampleRepository.Update(sample, User.Identity.Name, false);

        entity.Document = documentRepository.Add(new Document
        {
            ContentType = model.Document.ContentType,
            Length = model.Document.ContentData.LongLength,
            Name = model.Document.Name,
            Description = model.Document.Description
        }, User.Identity.Name, false);

        documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);
    }

    protected override void PreEdit(Assessment entity, AssessmentInputModel model)
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

    protected override void PostCreate(Assessment entity, AssessmentInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(Assessment entity, AssessmentInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}