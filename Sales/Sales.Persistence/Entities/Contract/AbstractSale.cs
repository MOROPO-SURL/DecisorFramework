namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities.Contract
{
    public abstract class AbstractSale : Core.Persistence.Entities.Contract.IFullFeatureEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SellerId))]
        public Domain.Persistence.Entities.Employee Seller { get; set; }
        public System.Guid SellerId { get; set; }
    }
}

