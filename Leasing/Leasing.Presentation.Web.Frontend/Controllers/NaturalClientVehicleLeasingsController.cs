using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/fwrk/leasing/[controller]")]
[ApiController]
public class NaturalClientVehicleLeasingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<NaturalClientVehicleLeasing, System.Guid, NaturalClientVehicleLeasingInputModel, NaturalClientVehicleLeasingDisplayModel>
{
    private readonly IEntityRepository<NaturalClient, System.Guid> clientRepository;
    private readonly IEntityRepository<VehicleLeasePersonPostulation, System.Guid> postulationRepository;
    private readonly IEntityRepository<VehicleLeaseOffer, System.Guid> offerRepository;
    private readonly IEntityRepository<NaturalClientVehicleLeaseContract, System.Guid> contractRepository;
    private readonly IEntityRepository<Vehicle, System.Guid> vehicleRepository;
    private readonly IEntityRepository<DriveLicence, System.Guid> driveLicenceRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public NaturalClientVehicleLeasingsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<DriveLicence, System.Guid> driveLicenceRepository, IEntityRepository<Vehicle, System.Guid> vehicleRepository, IEntityRepository<NaturalClientVehicleLeaseContract, System.Guid> contractRepository, IEntityRepository<VehicleLeaseOffer, System.Guid> offerRepository, IEntityRepository<VehicleLeasePersonPostulation, System.Guid> postulationRepository, IEntityRepository<NaturalClient, System.Guid> clientRepository, IEntityRepository<NaturalClientVehicleLeasing, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientVehicleLeasingsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientVehicleLeasingsController> logger) : base(repository, localizer, logger)
    {
        this.clientRepository = clientRepository;
        this.postulationRepository = postulationRepository;
        this.offerRepository = offerRepository;
        this.contractRepository = contractRepository;
        this.vehicleRepository = vehicleRepository;
        this.driveLicenceRepository = driveLicenceRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<NaturalClientVehicleLeasing, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<NaturalClientVehicleLeasing, object> GetOrderSelector()
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

    protected override NaturalClientVehicleLeasingDisplayModel EntityToDisplayModel(NaturalClientVehicleLeasing entity)
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

        model.DriverLicences = entity.DriveLicenceBridges.Select(bridge =>
        {
            var _model = new DriveLicenceDisplayModel();

            _model.Import(bridge.Stern);

            if (bridge.Stern.Contact.Identity.Image != null)
                _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Contact.Identity.Image.ContentType);

            return _model;
        }).ToArray();

        return model;
    }

    protected override void PreCreate(NaturalClientVehicleLeasing entity, NaturalClientVehicleLeasingInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (var _model in model.IncomingDriveLicences)
        {
            var _entity = driveLicenceRepository.Add(_model.Export(), User.Identity.Name, false);

            entity.DriveLicenceBridges.Add(new NaturalClientVehicleLeasingDriveLicenceBridge
            {
                ProwId = entity.Id,
                SternId = _entity.Id
            });
        }

        var postulation = postulationRepository.Get(model.PostulationId);

        var client = clientRepository.FindOneBy(_entity => _entity.ContactId == postulation.ContactId);

        entity.Contract = contractRepository.Add(new NaturalClientVehicleLeaseContract
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
            VehicleLeaseNaturalPostulationId = model.PostulationId
        }, User.Identity.Name, false);

        if (client != null)
        {
            entity.Contract.VehicleLeaseNaturalClientId = client.Id;

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

        var offer = offerRepository.Get(postulation.OfferId);

        offer.Archived = true;
        offer.LeasedAt = System.DateTime.Now;

        offerRepository.Update(offer, User.Identity.Name, false);

        var vehicle = vehicleRepository.Get(offer.Propousal.VehicleId);

        vehicle.Assignment = Domain.Persistence.Enumerations.VehicleAssignment.Leasing;

        vehicleRepository.Update(vehicle, User.Identity.Name, false);
    }

    protected override void PostCreate(NaturalClientVehicleLeasing entity, NaturalClientVehicleLeasingInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(NaturalClientVehicleLeasing entity, NaturalClientVehicleLeasingInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
