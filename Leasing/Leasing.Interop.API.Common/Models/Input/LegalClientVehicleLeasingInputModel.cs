using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientVehicleLeasingInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.LegalClientVehicleLeasing, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string OperativeLicenceCode { get; set; }

        public System.Guid PostulationId { get; set; }

        public System.Guid AgreementId { get; set; }

        public double Feed { get; set; }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind FeedDurationUnitMeasureKind { get; set; }

        public System.Guid PaymentTermId { get; set; }

        public System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel> Contacts { get; set; } = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>();

        public Persistence.Entities.LegalClientVehicleLeasing Export()
        {
            var entity = new Persistence.Entities.LegalClientVehicleLeasing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.LegalClientVehicleLeasing entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.LegalClientVehicleLeasing entity)
        {
            entity.OperativeLicenceCode = OperativeLicenceCode;

            entity.ContactBridges.Clear();

            entity.ContactBridges = Contacts.Select(model => new Persistence.Entities.LegalClientVehicleLeasingPersonContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
