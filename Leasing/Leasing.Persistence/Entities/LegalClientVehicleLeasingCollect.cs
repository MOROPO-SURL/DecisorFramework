namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeasingCollect : Financial.Persistence.Entities.Contract.AbstractCollect
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LegalClientVehicleLeasingId))]
        public LegalClientVehicleLeasing Leasing { get; set; }
        public System.Guid LegalClientVehicleLeasingId { get; set; }
    }
}
