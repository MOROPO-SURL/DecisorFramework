namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Workforce : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationalStructureId))]
        public Domain.Persistence.Entities.OrganizationalStructure OrganizationalStructure { get; set; }
        public System.Guid OrganizationalStructureId { get; set; }

        public System.Collections.Generic.ICollection<WorkforceOrganizationalUnit> OrganizationalUnits { get; set; }
    }
}