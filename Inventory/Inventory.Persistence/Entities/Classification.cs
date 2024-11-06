namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
	public class Classification : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
	{
		[System.ComponentModel.DataAnnotations.Key]
		public System.Guid Id { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        public string Description { get; set; }
    }
}

