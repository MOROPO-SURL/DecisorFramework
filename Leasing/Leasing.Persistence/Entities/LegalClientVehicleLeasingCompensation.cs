namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeasingCompensation : Contract.AbstractLeasingCompensation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public LegalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }

        public System.Collections.Generic.List<LegalClientVehicleLeasingCompensationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<LegalClientVehicleLeasingCompensationDocumentBridge>();
    }
}