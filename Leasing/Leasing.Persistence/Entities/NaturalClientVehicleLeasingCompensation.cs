namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasingCompensation : Contract.AbstractLeasingCompensation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public NaturalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }

        public System.Collections.Generic.List<NaturalClientVehicleLeasingCompensationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<NaturalClientVehicleLeasingCompensationDocumentBridge>();
    }
}