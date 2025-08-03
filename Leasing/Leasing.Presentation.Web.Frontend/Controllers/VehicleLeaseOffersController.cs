using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class VehicleLeaseOffersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<VehicleLeaseOffer, System.Guid, VehicleLeaseOfferInputModel, VehicleLeaseOfferDisplayModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public VehicleLeaseOffersController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<VehicleLeaseOffer, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeaseOffersController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleLeaseOffersController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<VehicleLeaseOffer, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<VehicleLeaseOffer, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult Enable(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult Disable(System.Guid key)
        {
            return NotFound();
        }

        protected override VehicleLeaseOfferDisplayModel EntityToDisplayModel(VehicleLeaseOffer entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Propousal.Vehicle.FeatureImage != null)
            {
                model.Propousal.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Propousal.Vehicle.FeatureImage.ContentType);
            }

            model.OrganizationPostulations = entity.OrganizationPostulations.Select(_entity =>
            {
                var result = new CommonLeaseOrganizationPostulationDisplayModel
                {
                    TaxIdentificationNumber = _entity.TaxIdentificationNumber,
                    StateIdentificationCode = _entity.StateIdentificationCode,
                    Argument = _entity.Argument
                };

                //if (_entity.CredentialDocument != null)
                //{
                //    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                //    result.CredentialDocument.Import(_entity.CredentialDocument);

                //    result.CredentialDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.CredentialDocument.ContentType);
                //}

                if (_entity.Contact != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                    result.Contact.Import(_entity.Contact);

                    result.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Contact.Identity.Image.ContentType);
                }

                return result;
            }).ToArray();
            model.PersonPostulations = entity.PersonPostulations.Select(_entity =>
            {
                var result = new CommonLeasePersonPostulationDisplayModel
                {
                    TaxIdentificationNumber = _entity.TaxIdentificationNumber,
                    Argument = _entity.Argument
                };

                //if (bridge.CredentialDocument != null)
                //{
                //    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                //    result.CredentialDocument.Import(bridge.CredentialDocument);

                //    result.CredentialDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.CredentialDocument.ContentType);
                //}

                if (_entity.Contact != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                    result.Contact.Import(_entity.Contact);
                }

                if (_entity.BusinessKind != null)
                {
                    result.BusinessKind = new Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                    result.BusinessKind.Import(_entity.BusinessKind);
                }

                return result;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingOrganizationPostulations)
            {
                var bridge = new VehicleLeaseOrganizationPostulation
                {
                    OfferId = entity.Id,
                    ContactId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    StateIdentificationCode = _model.StateIdentificationCode,
                    Argument = _model.Argument
                };

                //if (_model.RawCredentialDocument != null)
                //{
                //    bridge.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                //}

                entity.OrganizationPostulations.Add(bridge);
            }

            foreach (var _model in model.IncomingPersonPostulations)
            {
                var _entity = new VehicleLeasePersonPostulation
                {
                    OfferId = entity.Id,
                    ContactId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    BusinessKindId = _model.BusinessKindId,
                    Argument = _model.Argument
                };

                //if (_model.RawCredentialDocument != null)
                //{
                //    bridge.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                //}

                entity.PersonPostulations.Add(_entity);
            }
        }

        protected override void PreEdit(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreEdit(entity, model);

            #region Organizations
            foreach (var _model in model.OutgoingOrganizationPostulations)
            {
                var _entity = entity.OrganizationPostulations.First(_entity => _entity.Id == _model.Id);

                entity.OrganizationPostulations.Remove(_entity);
            }

            foreach (var _model in model.EditionOrganizationPostulations)
            {
                var _entity = entity.OrganizationPostulations.First(_entity => _entity.Id == _model.Id);

                _entity.TaxIdentificationNumber = _model.TaxIdentificationNumber;
                _entity.StateIdentificationCode = _model.StateIdentificationCode;
                _entity.Argument = _model.Argument;
                
                //if (_model.RawCredentialDocument != null)
                //{
                //    bridge.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                //}
            }

            foreach (var _model in model.IncomingOrganizationPostulations)
            {
                var _entity = new VehicleLeaseOrganizationPostulation
                {
                    OfferId = entity.Id,
                    ContactId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    StateIdentificationCode = _model.StateIdentificationCode,
                    Argument = _model.Argument
                };

                //if (_model.RawCredentialDocument != null)
                //{
                //    _entity.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    _entity.CredentialDocumentId = _entity.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(_entity.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, _entity.CredentialDocument.ContentType);
                //}

                entity.OrganizationPostulations.Add(_entity);
            }
            #endregion

            #region PersonContacts
            foreach (var _model in model.OutgoingPersonPostulations)
            {
                var _entity = entity.PersonPostulations.First(_entity => _entity.Id == _model.Id);

                entity.PersonPostulations.Remove(_entity);
            }

            foreach (var _model in model.EditionPersonPostulations)
            {
                var _entity = entity.PersonPostulations.First(_entity => _entity.Id == _model.Id);

                _entity.TaxIdentificationNumber = _model.TaxIdentificationNumber;
                _entity.Argument = _model.Argument;

                if (_entity.BusinessKindId != _model.BusinessKindId)
                {
                    _entity.BusinessKind = null;
                    _entity.BusinessKindId = _model.BusinessKindId;
                }

                //if (_model.RawCredentialDocument != null)
                //{
                //    _entity.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    _entity.CredentialDocumentId = _entity.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(_entity.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, _entity.CredentialDocument.ContentType);
                //}
            }

            foreach (var _model in model.IncomingPersonPostulations)
            {
                var _entity = new VehicleLeasePersonPostulation
                {
                    OfferId = entity.Id,
                    ContactId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    BusinessKindId = _model.BusinessKindId,
                    Argument = _model.Argument
                };

                //if (_model.RawCredentialDocument != null)
                //{
                //    _entity.CredentialDocument = documentRepository.Add(new Document
                //    {
                //        Id = _model.RawCredentialDocument.Id,
                //        Name = _model.RawCredentialDocument.Name,
                //        ContentType = _model.RawCredentialDocument.ContentType,
                //        Description = _model.RawCredentialDocument.Description,
                //        Length = _model.RawCredentialDocument.ContentData.Length
                //    }, User.Identity.Name, false);
                //    _entity.CredentialDocumentId = _entity.CredentialDocument.Id;

                //    documentFileManager.SaveDocumentFileContent(_entity.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, _entity.CredentialDocument.ContentType);
                //}

                entity.PersonPostulations.Add(_entity);
            }
            #endregion
        }

        //protected override void PostEdit(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        //{
        //    base.PostEdit(entity, model);

        //    foreach (var _model in model.OutgoingOrganizationPostulations)
        //    {
        //        documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
        //    }

        //    foreach (var _model in model.OutgoingPersonPostulations)
        //    {
        //        documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
        //    }
        //}
    }
}
