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
public class NaturalClientServicingContractsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NaturalClientServicingContract, System.Guid, NaturalClientServicingContractInputModel, NaturalClientServicingContractDisplayModel, NaturalClientServicingContractFilterModel>
{
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;

    public NaturalClientServicingContractsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<NaturalClientServicingContract, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientServicingContractsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientServicingContractsController> logger) : base(repository, localizer, logger)
    {
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<NaturalClientServicingContract, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<NaturalClientServicingContract, object> GetOrderSelector()
    {
        return entity => entity.Year * 1000 + entity.Index;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    protected override NaturalClientServicingContractDisplayModel EntityToDisplayModel(NaturalClientServicingContract entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Client.Contact.Identity.Image != null)
        {
            model.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Client.Contact.Identity.Image.ContentType);
        }

        if (entity.Document != null)
        {
            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            model.Document.Import(entity.Document);

            model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
        }

        return model;
    }

    protected override void PreCreate(NaturalClientServicingContract entity, NaturalClientServicingContractInputModel model)
    {
        base.PreCreate(entity, model);

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

    protected override void PreEdit(NaturalClientServicingContract entity, NaturalClientServicingContractInputModel model)
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
