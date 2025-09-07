namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractVehicleLeasing : AbstractLeasing
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string OperativeLicenceCode { get; set; }
    }
}
