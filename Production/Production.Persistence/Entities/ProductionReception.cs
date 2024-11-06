namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ProductionReception : Inventory.Persistence.Entities.Contract.AbstractReception
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductionId))]
        public Production Production { get; set; }
        public System.Guid? ProductionId { get; set; }
    }
}