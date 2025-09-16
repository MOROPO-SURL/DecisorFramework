namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientVehicleLeaseContractDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.LegalClientVehicleLeaseContract, int>
    {
        public int Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime StartAt { get; set; }

        public string Objective { get; set; }

        public Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel Client { get; set; }

        public double Feed { get; set; }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind FeedDurationUnitMeasureKind { get; set; }

        public Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get; set; }

        public void Import(Persistence.Entities.LegalClientVehicleLeaseContract entity)
        {
            Id = entity.Id;
            At = entity.At;
            StartAt = entity.StarAt;
            Objective = entity.Objective;

            if (entity.Postulation != null)
            {
                Vehicle = new Domain.Interop.API.Common.Models.Display.VehicleDisplayModel();

                Vehicle.Import(entity.Postulation.Offer.Propousal.Vehicle);
            }

            if (entity.Client != null)
            {
                Client = new Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel();

                Client.Import(entity.Client);
            }

            if (entity.PaymentTerm != null)
            {
                PaymentTerm = new Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel();

                PaymentTerm.Import(entity.PaymentTerm);
            }
        }
    }
}
