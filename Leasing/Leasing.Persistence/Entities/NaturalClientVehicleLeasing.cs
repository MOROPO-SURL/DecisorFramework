namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasing : Contract.AbstractVehicleLeasing
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContractId))]
        public NaturalClientVehicleLeaseContract Contract { get; set; }
        public System.Guid ContractId { get; set; }

        public System.Collections.Generic.List<NaturalClientVehicleLeasingPersonContactBridge> ContactBridges { get; set; } = new System.Collections.Generic.List<NaturalClientVehicleLeasingPersonContactBridge>();
    }
}
