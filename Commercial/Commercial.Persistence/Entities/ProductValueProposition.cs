namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ProductValueProposition : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.Contract.AbstractContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Inventory.Persistence.Entities.Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        public string Description { get; set; }

        public int Evaluation { get; set; }

        public System.Collections.Generic.IEnumerable<ProductValuePropositionRate> Rates { get; set; }

        public System.Collections.Generic.List<ProductValuePropositionImageBridge> ImageBridges { get; set; } = new System.Collections.Generic.List<ProductValuePropositionImageBridge>();
    }
}
