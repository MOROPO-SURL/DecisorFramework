namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class OrganizationalStructuringUnit : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public Enumerations.OrganizationalStructuringUnitKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationalUnitId))]
        public OrganizationalUnit OrganizationalUnit { get; set; }
        public System.Guid OrganizationalUnitId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public OrganizationalStructuringUnit Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(120)]
        public string Reference { get; set; }
    }
}
