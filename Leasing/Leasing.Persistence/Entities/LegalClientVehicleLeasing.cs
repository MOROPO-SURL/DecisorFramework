namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeasing : Contract.AbstractVehicleLeasing
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContractId))]
        public LegalClientVehicleLeaseContract Contract { get; set; }
        public int ContractId { get; set; }

        public System.Collections.Generic.List<LegalClientVehicleLeasingPersonContactBridge> ContactBridges { get; set; } = new System.Collections.Generic.List<LegalClientVehicleLeasingPersonContactBridge>();
    }
}