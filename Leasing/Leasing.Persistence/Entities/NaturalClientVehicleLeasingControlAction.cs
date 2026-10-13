namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasingControlAction : Contract.AbstractLeasingControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public NaturalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
