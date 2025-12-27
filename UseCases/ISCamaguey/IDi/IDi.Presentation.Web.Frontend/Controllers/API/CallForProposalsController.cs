using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class CallForProposalsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<CallForProposal, System.Guid, CallForProposalInputModel, CallForProposalDisplayModel, CallForProposalFilterModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public CallForProposalsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<CallForProposal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CallForProposalsController> localizer, Microsoft.Extensions.Logging.ILogger<CallForProposalsController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<CallForProposal, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<CallForProposal, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        protected override CallForProposalDisplayModel EntityToDisplayModel(CallForProposal entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Financier.Contact.Identity.Image != null)
            {
                model.Financier.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Financier.Contact.Identity.Image.ContentType);
            }

            model.Documents = entity.DocumentBridges.Select(bridge =>
            {
                var _model = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(CallForProposal entity, CallForProposalInputModel model)
        {
            base.PreCreate(entity, model);

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

                entity.DocumentBridges.Add(new CallForProposalDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });

                documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
            }
        }

        protected override void PreEdit(CallForProposal entity, CallForProposalInputModel model)
        {
            base.PreEdit(entity, model);

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

                entity.DocumentBridges.Add(new CallForProposalDocumentBridge
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
