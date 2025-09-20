using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class LegalClientPropertyLeasingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<LegalClientPropertyLeasing, System.Guid, LegalClientPropertyLeasingInputModel, LegalClientPropertyLeasingDisplayModel>
    {
        private readonly IEntityRepository<LegalClient, System.Guid> clientRepository;
        private readonly IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> postulationRepository;
        private readonly IEntityRepository<PropertyLeaseOffer, System.Guid> offerRepository;
        private readonly IEntityRepository<LegalClientPropertyLeaseContract, int> contractRepository;
        private readonly IEntityRepository<PropertySpace, System.Guid> propertySpaceRepository;
        private readonly IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository;

        public LegalClientPropertyLeasingsController(IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository, IEntityRepository<PropertySpace, System.Guid> propertySpaceRepository, IEntityRepository<LegalClientPropertyLeaseContract, int> contractRepository, IEntityRepository<PropertyLeaseOffer, System.Guid> offerRepository, IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> postulationRepository, IEntityRepository<LegalClient, System.Guid> clientRepository, IEntityRepository<LegalClientPropertyLeasing, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientPropertyLeasingsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientPropertyLeasingsController> logger) : base(repository, localizer, logger)
        {
            this.clientRepository = clientRepository;
            this.postulationRepository = postulationRepository;
            this.offerRepository = offerRepository;
            this.contractRepository = contractRepository;
            this.propertySpaceRepository = propertySpaceRepository;
            this.spaceLeasePropousalRepository = spaceLeasePropousalRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalClientPropertyLeasing, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientPropertyLeasing, object> GetOrderSelector()
        {
            return entity => entity.Id;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override LegalClientPropertyLeasingDisplayModel EntityToDisplayModel(LegalClientPropertyLeasing entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.Contract = new LegalClientPropertyLeaseContractDisplayModel();

            model.Contract.Import(entity.Contract);

            if (entity.Contract.Client.Contact.Identity.Image != null)
            {
                model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            if (entity.Contract.Postulation.Offer.Propousal.Property.FeatureImage != null)
            {
                model.Contract.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            var members = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>();

            foreach (var bridge in entity.ContactBridges)
            {
                var _model = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                _model.Import(bridge.Stern);

                if (bridge.Stern.Identity.Image != null)
                    _model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);

                members.Add(_model);
            }

            model.Workers = [.. members];

            return model;
        }

        protected override void PreCreate(LegalClientPropertyLeasing entity, LegalClientPropertyLeasingInputModel model)
        {
            base.PreCreate(entity, model);

            var postulation = postulationRepository.Get(model.PostulationId);

            foreach (var bridge in postulation.PropertySpaceBridges)
            {
                var space = propertySpaceRepository.Get(bridge.Stern.PropertySpaceId);

                if (space.Assignment != null) throw new Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("El espacio a contratar ya se encuentra en uso.");

                space.Assignment = Domain.Persistence.Enumerations.PropertyAssignment.Leasing;

                propertySpaceRepository.Update(space, User.Identity.Name, false);
            }

            postulation.Archived = true;

            postulationRepository.Update(postulation, User.Identity.Name, false);

            var client = clientRepository.FindOneBy(_entity => _entity.ContactId == postulation.ContactId);

            entity.Contract = contractRepository.Add(new LegalClientPropertyLeaseContract
            {
                Id = model.Index,
                Year = model.StartAt.Year,
                StarAt = model.StartAt,
                Objective = model.Objective,
                DurationUnitCount = model.DurationUnitCount,
                DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                Priority = model.Priority,
                Feed = model.Feed,
                PaymentTermId = model.PaymentTermId,
                PropertyLeaseLegalPostulationId = model.PostulationId
            }, User.Identity.Name, false);

            if (client != null)
            {
                entity.Contract.PropertyLeaseLegalClientId = client.Id;
            }
            else
            {
                var clientId = System.Guid.NewGuid();

                entity.Contract.Client = clientRepository.Add(new LegalClient
                {
                    Id = clientId,
                    Enabled = true,
                    Priority = postulation.Contact.Priority,
                    ContactId = postulation.ContactId,
                    DefaultPaymentTermId = model.PaymentTermId,
                    DocumentBridges = postulation.DocumentBridges.Select(bridge => new LegalClientDocumentBridge
                    {
                        ProwId = clientId,
                        SternId = bridge.SternId
                    }).ToList()
                }, User.Identity.Name, false);
            }

            var isOfferArchivable = true;

            var offer = offerRepository.Get(postulation.OfferId);

            var spaceLeasePropousals = spaceLeasePropousalRepository.FindBy(_entity => _entity.PropertyLeasePropousalId == offer.PropousalId).ToArray();

            foreach (var _entity in spaceLeasePropousals)
            {
                if (_entity.PropertySpace.Assignment == null)
                {
                    isOfferArchivable = false;

                    break;
                }
            }

            if (!isOfferArchivable) return;

            offer.Archived = true;
            offer.LeasedAt = System.DateTime.Now;

            offerRepository.Update(offer, User.Identity.Name, false);
        }
    }
}
