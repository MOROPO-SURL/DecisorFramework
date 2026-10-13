namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeasingControlAction : Contract.AbstractLeasingControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public LegalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
