namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class ProductionSample : Contract.AbstractSample
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductionId))]
        public Framework.Decisor.Production.Persistence.Entities.Production Production { get; set; }
        public System.Guid ProductionId { get; set; }
    }
}
