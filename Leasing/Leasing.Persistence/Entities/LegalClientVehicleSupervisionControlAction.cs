namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleSupervisionControlAction : Contract.AbstractSupervisionControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public LegalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
