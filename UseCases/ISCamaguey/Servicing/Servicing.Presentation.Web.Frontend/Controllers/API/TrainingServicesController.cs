using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/servicing/[controller]")]
    [ApiController]
    public class TrainingServicesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<TrainingService, System.Guid, TrainingServiceInputModel, TrainingServiceDisplayModel, TrainingServiceFilterModel>
    {
        private readonly IEntityRepository<TrainingServiceStep, System.Guid> stepRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public TrainingServicesController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<TrainingServiceStep, System.Guid> stepRepository, IEntityRepository<TrainingService, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TrainingServicesController> localizer, Microsoft.Extensions.Logging.ILogger<TrainingServicesController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<TrainingService, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<TrainingService, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override TrainingServiceDisplayModel EntityToDisplayModel(TrainingService entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Responsible.Contact.Identity.Image != null)
            {
                model.Responsible.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Contact.Identity.Image.ContentType);
            }

            model.Members = entity.EmployeeBridges.Select(bridge =>
            {
                var _model = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Contact.Identity.Image != null)
                {
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);
                }

                return _model;
            }).ToArray();

            model.Steps = stepRepository.FindBy(_entity => _entity.ServiceId == entity.Id && _entity.ParentId == null).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
            {
                var _model = new TrainingServiceStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            model.Documents = entity.DocumentBridges.Select(bridge =>
            {
                var _model = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(TrainingService entity, TrainingServiceInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingSteps)
            {
                var _entity = _model.Export();

                _entity.ServiceId = entity.Id;

                stepRepository.Add(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingDocuments)
            {
                var __entity = documentRepository.Add(new Document
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ContentType = _model.ContentType,
                    Description = _model.Description,
                    Length = _model.ContentData.Length
                }, User.Identity.Name, false);

                entity.DocumentBridges.Add(new TrainingServiceDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });

                documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
            }
        }

        protected override void PreEdit(TrainingService entity, TrainingServiceInputModel model)
        {
            base.PreEdit(entity, model);

            #region Steps

            foreach (var _model in model.OutgoingSteps)
            {
                stepRepository.Delete(new TrainingServiceStep { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionSteps)
            {
                var _entity = stepRepository.Get(_model.Id);

                _model.Mergue(_entity);

                stepRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingSteps)
            {
                var _entity = _model.Export();

                _entity.ServiceId = entity.Id;

                stepRepository.Add(_entity, User.Identity.Name, false);
            }

            #endregion

            #region Documents

            foreach (var _model in model.OutgoingDocuments)
            {
                var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                documentRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionDocuments)
            {
                var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _model.Mergue(_entity);

                documentRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingDocuments)
            {
                var _entity = documentRepository.Add(new Document
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ContentType = _model.ContentType,
                    Description = _model.Description,
                    Length = _model.ContentData.Length
                }, User.Identity.Name, false);

                entity.DocumentBridges.Add(new TrainingServiceDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }

            #endregion
        }
    }
}
