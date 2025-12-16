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
    public class LegalClientVehicleLeasingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<LegalClientVehicleLeasing, System.Guid, LegalClientVehicleLeasingInputModel, LegalClientVehicleLeasingDisplayModel>
    {
        private readonly IEntityRepository<LegalClient, System.Guid> clientRepository;
        private readonly IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> postulationRepository;
        private readonly IEntityRepository<VehicleLeaseOffer, System.Guid> offerRepository;
        private readonly IEntityRepository<LegalClientVehicleLeaseContract, System.Guid> contractRepository;
        private readonly IEntityRepository<Vehicle, System.Guid> vehicleRepository;

        public LegalClientVehicleLeasingsController(IEntityRepository<Vehicle, System.Guid> vehicleRepository, IEntityRepository<LegalClientVehicleLeaseContract, System.Guid> contractRepository, IEntityRepository<VehicleLeaseOffer, System.Guid> offerRepository, IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> postulationRepository, IEntityRepository<LegalClient, System.Guid> clientRepository, IEntityRepository<LegalClientVehicleLeasing, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientVehicleLeasingsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientVehicleLeasingsController> logger) : base(repository, localizer, logger)
        {
            this.clientRepository = clientRepository;
            this.postulationRepository = postulationRepository;
            this.offerRepository = offerRepository;
            this.contractRepository = contractRepository;
            this.vehicleRepository = vehicleRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalClientVehicleLeasing, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalClientVehicleLeasing, object> GetOrderSelector()
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

        protected override LegalClientVehicleLeasingDisplayModel EntityToDisplayModel(LegalClientVehicleLeasing entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contract.Client.Contact.Identity.Image != null)
            {
                model.Contract.Client.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Client.Contact.Identity.Image.ContentType);
            }

            if (entity.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage != null)
            {
                model.Contract.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Postulation.Offer.Propousal.Vehicle.FeatureImage.ContentType);
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

            model.Drivers = [.. members];

            return model;
        }

        protected override void PreCreate(LegalClientVehicleLeasing entity, LegalClientVehicleLeasingInputModel model)
        {
            base.PreCreate(entity, model);

            var postulation = postulationRepository.Get(model.PostulationId);

            var client = clientRepository.FindOneBy(_entity => _entity.ContactId == postulation.ContactId);

            entity.Contract = contractRepository.Add(new LegalClientVehicleLeaseContract
            {
                Id = System.Guid.NewGuid(),
                Index = model.Index,
                Year = model.StartAt.Year,
                StarAt = model.StartAt,
                Objective = model.Objective,
                DurationUnitCount = model.DurationUnitCount,
                DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                Feed = model.Feed,
                PaymentTermId = model.PaymentTermId,
                BankAccountId = postulation.BankAccountId,
                VehicleLeaseLegalPostulationId = model.PostulationId
            }, User.Identity.Name, false);

            if (client != null)
            {
                entity.Contract.VehicleLeaseLegalClientId = client.Id;

                if (!client.BankAccountBridges.Any(bridge => bridge.SternId == postulation.BankAccountId))
                {
                    client.BankAccountBridges.Add(new LegalClientBankAccountBridge { ProwId = client.Id, SternId = postulation.BankAccountId });

                    clientRepository.Update(client, User.Identity.Name, false);
                }
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
                    BankAccountBridges = [new LegalClientBankAccountBridge { ProwId = clientId, SternId = postulation.BankAccountId }],
                    DocumentBridges = postulation.DocumentBridges.Select(bridge => new LegalClientDocumentBridge
                    {
                        ProwId = clientId,
                        SternId = bridge.SternId
                    }).ToList()
                }, User.Identity.Name, false);
            }

            var offer = offerRepository.Get(postulation.OfferId); 
            
            offer.Archived = true;
            offer.LeasedAt = System.DateTime.Now;

            offerRepository.Update(offer, User.Identity.Name, false);

            var vehicle = vehicleRepository.Get(offer.Propousal.VehicleId);

            vehicle.Assignment = Domain.Persistence.Enumerations.VehicleAssignment.Leasing;

            vehicleRepository.Update(vehicle, User.Identity.Name, false);
        }
    }
}
