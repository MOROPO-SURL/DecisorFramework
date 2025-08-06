using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class PropertyLeaseOffersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<PropertyLeaseOffer, System.Guid, PropertyLeaseOfferInputModel, PropertyLeaseOfferDisplayModel>
    {
        private readonly IEntityRepository<PropertyLeasePropousal, System.Guid> propertyLeasePropousalRepository;

        public PropertyLeaseOffersController(IEntityRepository<PropertyLeasePropousal, System.Guid> propertyLeasePropousalRepository, IEntityRepository<PropertyLeaseOffer, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeaseOffersController> localizer, Microsoft.Extensions.Logging.ILogger<PropertyLeaseOffersController> logger) : base(repository, localizer, logger)
        {
            this.propertyLeasePropousalRepository = propertyLeasePropousalRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PropertyLeaseOffer, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PropertyLeaseOffer, object> GetOrderSelector()
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

        protected override PropertyLeaseOfferDisplayModel EntityToDisplayModel(PropertyLeaseOffer entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Propousal.Property.FeatureImage != null)
            {
                model.Propousal.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Propousal.Property.FeatureImage.ContentType);
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

                //if (_entity.CredentialDocument != null)
                //{
                //    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                //    result.CredentialDocument.Import(_entity.CredentialDocument);

                //    result.CredentialDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.CredentialDocument.ContentType);
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

        protected override void PreCreate(PropertyLeaseOffer entity, PropertyLeaseOfferInputModel model)
        {
            base.PreCreate(entity, model);

            var propousal = propertyLeasePropousalRepository.Get(model.PropousalId);
            
            propousal.Archived = true;

            propertyLeasePropousalRepository.Update(propousal, User.Identity.Name, false);

            entity.PropousalId = model.PropousalId;

            foreach (var _model in model.IncomingOrganizationPostulations)
            {
                var _entity = new PropertyLeaseOrganizationPostulation
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

            foreach (var _model in model.IncomingPersonPostulations)
            {
                var _entity = new PropertyLeasePersonPostulation
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
        }

        protected override void PreEdit(PropertyLeaseOffer entity, PropertyLeaseOfferInputModel model)
        {
            base.PreEdit(entity, model);

            if (entity.PropousalId != model.PropousalId)
            {
                var oldPropousal = propertyLeasePropousalRepository.Get(entity.PropousalId);

                oldPropousal.Archived = false;

                propertyLeasePropousalRepository.Update(oldPropousal, User.Identity.Name, false);

                entity.Propousal = null;
                entity.PropousalId = model.PropousalId;

                var newPropousal = propertyLeasePropousalRepository.Get(model.PropousalId);

                newPropousal.Archived = true;

                propertyLeasePropousalRepository.Update(newPropousal, User.Identity.Name, false);
            }

            #region OrganizationContacts
            foreach (var _model in model.OutgoingOrganizationPostulations)
            {
                var _entity = entity.OrganizationPostulations.First(_entity => _entity.Id == _model.Id);

                entity.OrganizationPostulations.Remove(_entity);
            }

            foreach (var _model in model.EditionOrganizationPostulations)
            {
                var _entity = entity.OrganizationPostulations.First(bridge => bridge.Id == _model.Id);

                _entity.TaxIdentificationNumber = _model.TaxIdentificationNumber;
                _entity.StateIdentificationCode = _model.StateIdentificationCode;
                _entity.Argument = _model.Argument;

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

            foreach (var _model in model.IncomingOrganizationPostulations)
            {
                var _entity = new PropertyLeaseOrganizationPostulation
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
                var _entity = new PropertyLeasePersonPostulation
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

        //protected override void PostEdit(PropertyLeaseOffer entity, PropertyLeaseOfferInputModel model)
        //{
        //    base.PostEdit(entity, model);

        //    foreach (var _model in model.OutgoingOrganizationContactBridges)
        //    {
        //        documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
        //    }

        //    foreach (var _model in model.OutgoingPersonContactBridges)
        //    {
        //        documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
        //    }
        //}
    }
}
