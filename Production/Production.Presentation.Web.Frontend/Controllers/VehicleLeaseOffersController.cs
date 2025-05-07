using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Route("api/production/[controller]")]
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

            if (model.Vehicle.FeatureImage != null)
            {
                model.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Vehicle.FeatureImage.ContentType);
            }

            model.OrganizationContactBridges = entity.OrganizationContactBridges.Select(bridge =>
            {
                var result = new Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    StateIdentificationCode = bridge.StateIdentificationCode,
                    Argument = bridge.Argument
                };

                if (bridge.CredentialDocument != null)
                {
                    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    result.CredentialDocument.Import(bridge.CredentialDocument);

                    result.CredentialDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.CredentialDocument.ContentType);
                }

                if (bridge.Stern != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                    result.Contact.Import(bridge.Stern);

                    result.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
                }

                return result;
            }).ToArray();
            model.PersonContactBridges = entity.PersonContactBridges.Select(bridge =>
            {
                var result = new Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    Argument = bridge.Argument
                };

                if (bridge.CredentialDocument != null)
                {
                    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    result.CredentialDocument.Import(bridge.CredentialDocument);

                    result.CredentialDocument.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.CredentialDocument.ContentType);
                }

                if (bridge.Stern != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                    result.Contact.Import(bridge.Stern);
                }

                if (bridge.BusinessKind != null)
                {
                    result.BusinessKind = new Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                    result.BusinessKind.Import(bridge.BusinessKind);
                }

                return result;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingOrganizationContactBridges)
            {
                var bridge = new VehicleLeaseOfferOrganizationContactBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    StateIdentificationCode = _model.StateIdentificationCode,
                    Argument = _model.Argument
                };

                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }

                entity.OrganizationContactBridges.Add(bridge);
            }

            foreach (var _model in model.IncomingPersonContactBridges)
            {
                var bridge = new VehicleLeaseOfferPersonContactBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    BusinessKindId = _model.BusinessKindId,
                    Argument = _model.Argument
                };

                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }

                entity.PersonContactBridges.Add(bridge);
            }
        }

        protected override void PreEdit(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreEdit(entity, model);

            #region OrganizationContacts
            foreach (var _model in model.OutgoingOrganizationContactBridges)
            {
                var bridge = entity.OrganizationContactBridges.First(bridge => bridge.SternId == _model.Contact.Id);

                entity.OrganizationContactBridges.Remove(bridge);
            }

            foreach (var _model in model.EditionOrganizationContactBridges)
            {
                var bridge = entity.OrganizationContactBridges.First(bridge => bridge.SternId == _model.ContactId);

                bridge.TaxIdentificationNumber = _model.TaxIdentificationNumber;
                bridge.StateIdentificationCode = _model.StateIdentificationCode;
                bridge.Argument = _model.Argument;
                
                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }
            }

            foreach (var _model in model.IncomingOrganizationContactBridges)
            {
                var bridge = new VehicleLeaseOfferOrganizationContactBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    StateIdentificationCode = _model.StateIdentificationCode,
                    Argument = _model.Argument
                };

                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }

                entity.OrganizationContactBridges.Add(bridge);
            }
            #endregion

            #region PersonContacts
            foreach (var _model in model.OutgoingPersonContactBridges)
            {
                var bridge = entity.PersonContactBridges.First(bridge => bridge.SternId == _model.Contact.Id);

                entity.PersonContactBridges.Remove(bridge);
            }

            foreach (var _model in model.EditionPersonContactBridges)
            {
                var bridge = entity.PersonContactBridges.First(bridge => bridge.SternId == _model.ContactId);

                bridge.TaxIdentificationNumber = _model.TaxIdentificationNumber;
                bridge.Argument = _model.Argument;

                if (bridge.BusinessKindId != _model.BusinessKindId)
                {
                    bridge.BusinessKind = null;
                    bridge.BusinessKindId = _model.BusinessKindId;
                }

                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }
            }

            foreach (var _model in model.IncomingPersonContactBridges)
            {
                var bridge = new VehicleLeaseOfferPersonContactBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.ContactId,
                    TaxIdentificationNumber = _model.TaxIdentificationNumber,
                    BusinessKindId = _model.BusinessKindId,
                    Argument = _model.Argument
                };

                if (_model.RawCredentialDocument != null)
                {
                    bridge.CredentialDocument = documentRepository.Add(new Document
                    {
                        Id = _model.RawCredentialDocument.Id,
                        Name = _model.RawCredentialDocument.Name,
                        ContentType = _model.RawCredentialDocument.ContentType,
                        Description = _model.RawCredentialDocument.Description,
                        Length = _model.RawCredentialDocument.ContentData.Length
                    }, User.Identity.Name, false);
                    bridge.CredentialDocumentId = bridge.CredentialDocument.Id;

                    documentFileManager.SaveDocumentFileContent(bridge.CredentialDocument.Id, _model.RawCredentialDocument.ContentData, bridge.CredentialDocument.ContentType);
                }

                entity.PersonContactBridges.Add(bridge);
            }
            #endregion
        }

        protected override void PostEdit(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PostEdit(entity, model);

            foreach (var _model in model.OutgoingOrganizationContactBridges)
            {
                documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
            }

            foreach (var _model in model.OutgoingPersonContactBridges)
            {
                documentFileManager.DeleteDocumentFile(new Document { Id = _model.CredentialDocument.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.CredentialDocument.Extension) });
            }
        }
    }
}
