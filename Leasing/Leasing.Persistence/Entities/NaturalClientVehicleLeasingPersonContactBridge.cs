namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasingPersonContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClientVehicleLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClientVehicleLeasing Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }
    }
}
