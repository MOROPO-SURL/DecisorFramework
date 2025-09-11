namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class SupervisionGroup : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RepresentativeId))]
        public Domain.Persistence.Entities.Employee Representative { get; set; }
        public System.Guid RepresentativeId { get; set; }

        public System.Collections.Generic.List<SupervisionGroupEmployeeBridge> EmployeeBridges { get; set; } = new System.Collections.Generic.List<SupervisionGroupEmployeeBridge>();
    }
}
