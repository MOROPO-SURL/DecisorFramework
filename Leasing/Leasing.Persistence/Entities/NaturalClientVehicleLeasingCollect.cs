namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientVehicleLeasingCollect : Financial.Persistence.Entities.Contract.AbstractCollect
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NaturalClientVehicleLeasingId))]
        public NaturalClientVehicleLeasing Leasing { get; set; }
        public System.Guid NaturalClientVehicleLeasingId { get; set; }
    }
}