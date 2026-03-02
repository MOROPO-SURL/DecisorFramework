namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class AdministrativeEntity : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public AdministrativeEntityKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        public Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public AdministrativeEntity Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SocialPropertyId))]
        public Property SocialProperty { get; set; }
        public System.Guid? SocialPropertyId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationalStructureId))]
        public OrganizationalStructure OrganizationalStructure { get; set; }
        public System.Guid OrganizationalStructureId { get; set; }
    }
}
