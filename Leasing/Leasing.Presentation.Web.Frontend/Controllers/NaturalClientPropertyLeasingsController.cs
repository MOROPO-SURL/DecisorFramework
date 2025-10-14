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
    [Route("api/fwrk/leasing/[controller]")]
    [ApiController]
    public class NaturalClientPropertyLeasingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<NaturalClientPropertyLeasing, System.Guid, NaturalClientPropertyLeasingInputModel, NaturalClientPropertyLeasingDisplayModel>
    {
        private readonly IEntityRepository<NaturalClient, System.Guid> clientRepository;
        private readonly IEntityRepository<PropertyLeasePersonPostulation, System.Guid> postulationRepository;
        private readonly IEntityRepository<PropertyLeaseOffer, System.Guid> offerRepository;
        private readonly IEntityRepository<NaturalClientPropertyLeaseContract, int> contractRepository;
        private readonly IEntityRepository<PropertySpace, System.Guid> propertySpaceRepository;
        private readonly IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository;

        public NaturalClientPropertyLeasingsController(IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository, IEntityRepository<PropertySpace, System.Guid> propertySpaceRepository, IEntityRepository<NaturalClientPropertyLeaseContract, int> contractRepository, IEntityRepository<PropertyLeaseOffer, System.Guid> offerRepository, IEntityRepository<PropertyLeasePersonPostulation, System.Guid> postulationRepository, IEntityRepository<NaturalClient, System.Guid> clientRepository, IEntityRepository<NaturalClientPropertyLeasing, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientPropertyLeasingsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientPropertyLeasingsController> logger) : base(repository, localizer, logger)
        {
            this.clientRepository = clientRepository;
            this.postulationRepository = postulationRepository;
            this.offerRepository = offerRepository;
            this.contractRepository = contractRepository;
            this.propertySpaceRepository = propertySpaceRepository;
            this.spaceLeasePropousalRepository = spaceLeasePropousalRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalClientPropertyLeasing, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NaturalClientPropertyLeasing, object> GetOrderSelector()
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

        protected override NaturalClientPropertyLeasingDisplayModel EntityToDisplayModel(NaturalClientPropertyLeasing entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contract.Client.Contact.Identity.Image != null)
            {
                model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            if (entity.Contract.Postulation.Offer.Propousal.Property.FeatureImage != null)
            {
                model.Contract.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Postulation.Offer.Propousal.Property.FeatureImage.ContentType);
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

        protected override void PreCreate(NaturalClientPropertyLeasing entity, NaturalClientPropertyLeasingInputModel model)
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

            entity.Contract = contractRepository.Add(new NaturalClientPropertyLeaseContract
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
                BankAccountId = postulation.BankAccountId,
                PropertyLeaseNaturalPostulationId = model.PostulationId
            }, User.Identity.Name, false);

            if (client != null)
            {
                entity.Contract.PropertyLeaseNaturalClientId = client.Id;

                if (!client.BankAccountBridges.Any(bridge => bridge.SternId == postulation.BankAccountId))
                {
                    client.BankAccountBridges.Add(new NaturalClientBankAccountBridge { ProwId = client.Id, SternId = postulation.BankAccountId });

                    clientRepository.Update(client, User.Identity.Name, false);
                }
            }
            else
            {
                var clientId = System.Guid.NewGuid();

                entity.Contract.Client = clientRepository.Add(new NaturalClient
                {
                    Id = clientId,
                    Enabled = true,
                    Priority = postulation.Contact.Priority,
                    ContactId = postulation.ContactId,
                    DefaultPaymentTermId = model.PaymentTermId,
                    BankAccountBridges = [new NaturalClientBankAccountBridge { ProwId = clientId, SternId = postulation.BankAccountId }],
                    DocumentBridges = postulation.DocumentBridges.Select(bridge => new NaturalClientDocumentBridge
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
