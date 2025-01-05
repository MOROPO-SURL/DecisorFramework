namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class SalaryStandard : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public double Fee { get; set; }
    }
}
