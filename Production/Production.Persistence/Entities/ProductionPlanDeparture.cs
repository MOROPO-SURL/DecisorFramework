namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ProductionPlanDeparture : Inventory.Persistence.Entities.Contract.AbstractDeparture
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductionId))]
        public Production Production { get; set; }
        public System.Guid? ProductionId { get; set; }
    }
}

