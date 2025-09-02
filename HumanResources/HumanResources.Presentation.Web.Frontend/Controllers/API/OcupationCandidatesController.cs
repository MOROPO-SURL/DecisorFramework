using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OcupationCandidatesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<OcupationCandidate, System.Guid, OcupationCandidateInputModel, OcupationCandidateDisplayModel, OcupationCandidateFilterModel>
    {
        private readonly IEntityRepository<VacantPostulation, System.Guid> postulationRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public OcupationCandidatesController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<VacantPostulation, System.Guid> postulationRepository, IEntityRepository<OcupationCandidate, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OcupationCandidatesController> localizer, ILogger<OcupationCandidatesController> logger) : base(repository, localizer, logger)
        {
            this.postulationRepository = postulationRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<OcupationCandidate, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<OcupationCandidate, object> GetOrderSelector()
        {
            return entity => entity.Postulation.Vacant.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override OcupationCandidateDisplayModel EntityToDisplayModel(OcupationCandidate entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Postulation.Contact.Identity.Image != null)
            {
                model.Postulation.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Postulation.Contact.Identity.Image.ContentType);
            }

            if (entity.Responsible.Contact.Identity.Image != null)
            {
                model.Responsible.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Contact.Identity.Image.ContentType);
            }

            if (model.RawMedicalCheckDocument != null)
            {
                model.RawMedicalCheckDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawMedicalCheckDocument.ContentType);
            }

            if (model.RawPhysicologicalCheckDocument != null)
            {
                model.RawPhysicologicalCheckDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawPhysicologicalCheckDocument.ContentType);
            }

            if (model.RawDefenseStatusCheckDocument != null)
            {
                model.RawDefenseStatusCheckDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawDefenseStatusCheckDocument.ContentType);
            }

            if (model.RawResearchResultDocument != null)
            {
                model.RawResearchResultDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawResearchResultDocument.ContentType);
            }

            if (model.RawModelDocument != null)
            {
                model.RawModelDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.RawModelDocument.ContentType);
            }

            return model;
        }

        protected override void PreCreate(OcupationCandidate entity, OcupationCandidateInputModel model)
        {
            base.PreCreate(entity, model);

            var postulation = postulationRepository.Get(model.PostulationId);

            postulation.Archived = true;

            postulationRepository.Update(postulation, User.Identity.Name, false);

            if (model.RawMedicalCheckDocument != null)
            {
                entity.RawMedicalCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawMedicalCheckDocument.ContentType,
                    Length = model.RawMedicalCheckDocument.ContentData.LongLength,
                    Name = model.RawMedicalCheckDocument.Name,
                    Description = model.RawMedicalCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawMedicalCheckDocument.Id, model.RawMedicalCheckDocument.ContentData, model.RawMedicalCheckDocument.ContentType);
            }

            if (model.RawPhysicologicalCheckDocument != null)
            {
                entity.RawPhysicologicalCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawPhysicologicalCheckDocument.ContentType,
                    Length = model.RawPhysicologicalCheckDocument.ContentData.LongLength,
                    Name = model.RawPhysicologicalCheckDocument.Name,
                    Description = model.RawPhysicologicalCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawPhysicologicalCheckDocument.Id, model.RawPhysicologicalCheckDocument.ContentData, model.RawPhysicologicalCheckDocument.ContentType);
            }

            if (model.RawDefenseStatusCheckDocument != null)
            {
                entity.RawDefenseStatusCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawDefenseStatusCheckDocument.ContentType,
                    Length = model.RawDefenseStatusCheckDocument.ContentData.LongLength,
                    Name = model.RawDefenseStatusCheckDocument.Name,
                    Description = model.RawDefenseStatusCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawDefenseStatusCheckDocument.Id, model.RawDefenseStatusCheckDocument.ContentData, model.RawDefenseStatusCheckDocument.ContentType);
            }

            if (model.RawResearchResultDocument != null)
            {
                entity.RawResearchResultDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawResearchResultDocument.ContentType,
                    Length = model.RawResearchResultDocument.ContentData.LongLength,
                    Name = model.RawResearchResultDocument.Name,
                    Description = model.RawResearchResultDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawResearchResultDocument.Id, model.RawResearchResultDocument.ContentData, model.RawResearchResultDocument.ContentType);
            }

            if (model.RawModelDocument != null)
            {
                entity.RawModelDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawModelDocument.ContentType,
                    Length = model.RawModelDocument.ContentData.LongLength,
                    Name = model.RawModelDocument.Name,
                    Description = model.RawModelDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawModelDocument.Id, model.RawModelDocument.ContentData, model.RawModelDocument.ContentType);
            }
        }

        protected override void PreEdit(OcupationCandidate entity, OcupationCandidateInputModel model)
        {
            base.PreEdit(entity, model);

            if (entity.PostulationId != model.PostulationId)
            {
                var oldPostulation = postulationRepository.Get(entity.PostulationId);

                oldPostulation.Archived = false;

                postulationRepository.Update(oldPostulation, User.Identity.Name, false);

                entity.Postulation = null;
                entity.PostulationId = model.PostulationId;

                var newPostulation = postulationRepository.Get(model.PostulationId);

                newPostulation.Archived = true;

                postulationRepository.Update(newPostulation, User.Identity.Name, false);
            }

            if (model.RawMedicalCheckDocument != null)
            {
                entity.RawMedicalCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawMedicalCheckDocument.ContentType,
                    Length = model.RawMedicalCheckDocument.ContentData.LongLength,
                    Name = model.RawMedicalCheckDocument.Name,
                    Description = model.RawMedicalCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawMedicalCheckDocument.Id, model.RawMedicalCheckDocument.ContentData, model.RawMedicalCheckDocument.ContentType);
            }

            if (model.RawPhysicologicalCheckDocument != null)
            {
                entity.RawPhysicologicalCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawPhysicologicalCheckDocument.ContentType,
                    Length = model.RawPhysicologicalCheckDocument.ContentData.LongLength,
                    Name = model.RawPhysicologicalCheckDocument.Name,
                    Description = model.RawPhysicologicalCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawPhysicologicalCheckDocument.Id, model.RawPhysicologicalCheckDocument.ContentData, model.RawPhysicologicalCheckDocument.ContentType);
            }

            if (model.RawDefenseStatusCheckDocument != null)
            {
                entity.RawDefenseStatusCheckDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawDefenseStatusCheckDocument.ContentType,
                    Length = model.RawDefenseStatusCheckDocument.ContentData.LongLength,
                    Name = model.RawDefenseStatusCheckDocument.Name,
                    Description = model.RawDefenseStatusCheckDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawDefenseStatusCheckDocument.Id, model.RawDefenseStatusCheckDocument.ContentData, model.RawDefenseStatusCheckDocument.ContentType);
            }

            if (model.RawResearchResultDocument != null)
            {
                entity.RawResearchResultDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawResearchResultDocument.ContentType,
                    Length = model.RawResearchResultDocument.ContentData.LongLength,
                    Name = model.RawResearchResultDocument.Name,
                    Description = model.RawResearchResultDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawResearchResultDocument.Id, model.RawResearchResultDocument.ContentData, model.RawResearchResultDocument.ContentType);
            }

            if (model.RawModelDocument != null)
            {
                entity.RawModelDocument = documentRepository.Add(new Document
                {
                    ContentType = model.RawModelDocument.ContentType,
                    Length = model.RawModelDocument.ContentData.LongLength,
                    Name = model.RawModelDocument.Name,
                    Description = model.RawModelDocument.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.RawModelDocument.Id, model.RawModelDocument.ContentData, model.RawModelDocument.ContentType);
            }
        }

        protected override void PostEdit(OcupationCandidate entity, OcupationCandidateInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.RawMedicalCheckDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawMedicalCheckDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }

            if (model.RawPhysicologicalCheckDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawPhysicologicalCheckDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }

            if (model.RawDefenseStatusCheckDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawDefenseStatusCheckDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }

            if (model.RawResearchResultDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawResearchResultDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }

            if (model.RawModelDocument != null)
            {
                var oldRawDocument = documentRepository.Get(model.RawModelDocument.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }
        }
    }
}
