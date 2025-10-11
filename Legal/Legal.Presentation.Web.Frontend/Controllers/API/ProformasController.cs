using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/fwrk/legal/[controller]")]
    [ApiController]
    public class ProformasController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Proforma, System.Guid, ProformaInputModel, ProformaDisplayModel>
    {
        private readonly IBridgeRepository<ProformaClauseBridge, Proforma, System.Guid, Clause, System.Guid> proformaClauseBridgeRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public ProformasController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IBridgeRepository<ProformaClauseBridge, Proforma, System.Guid, Clause, System.Guid> proformaClauseBridgeRepository, IEntityRepository<Proforma, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProformasController> localizer, Microsoft.Extensions.Logging.ILogger<ProformasController> logger) : base(repository, localizer, logger)
        {
            this.proformaClauseBridgeRepository = proformaClauseBridgeRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Proforma, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Proforma, object> GetOrderSelector()
        {
            return entity => entity.Name;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProformaDisplayModel EntityToDisplayModel(Proforma entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.RawDocument != null)
            {
                model.RawDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawDocument.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Proforma entity, ProformaInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.Sections)
            {
                foreach (var __model in _model.Clauses)
                {
                    entity.ClauseBridges.Add(new Persistence.Entities.ProformaClauseBridge { ProwId = entity.Id, SternId = __model.Id, SectionId = _model.Section.Id });
                }
            }

            if (model.RawDocument != null)
            {
                entity.RawDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawDocument.ContentType,
                    Length = model.RawDocument.ContentData.LongLength,
                    Name = model.RawDocument.Name,
                    Description = model.RawDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawDocument.Id, model.RawDocument.ContentData, model.RawDocument.ContentType);
            }
        }

        protected override void PreEdit(Proforma entity, ProformaInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var bridge in entity.ClauseBridges)
            {
                proformaClauseBridgeRepository.Delete(bridge, User.Identity.Name, false);
            }

            entity.ClauseBridges.Clear();

            foreach (var _model in model.Sections)
            {
                foreach (var __model in _model.Clauses)
                {
                    entity.ClauseBridges.Add(new Persistence.Entities.ProformaClauseBridge { ProwId = entity.Id, SternId = __model.Id, SectionId = _model.Section.Id });
                }
            }

            if (model.RawDocument != null)
            {
                entity.RawDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawDocument.ContentType,
                    Length = model.RawDocument.ContentData.LongLength,
                    Name = model.RawDocument.Name,
                    Description = model.RawDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawDocument.Id, model.RawDocument.ContentData, model.RawDocument.ContentType);
            }
        }

        protected override void PostEdit(Proforma entity, ProformaInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.RawDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }
        }
    }
}
