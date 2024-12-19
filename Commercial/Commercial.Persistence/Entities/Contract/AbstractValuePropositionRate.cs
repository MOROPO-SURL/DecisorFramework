namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractValuePropositionRate : Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public double RegularCost { get; set; }

        public double? MinimumCost { get; set; }

        public double? MaximumCost { get; set; }

        public Financial.Persistence.Entities.Currency Currency { get; set; }
    }
}
