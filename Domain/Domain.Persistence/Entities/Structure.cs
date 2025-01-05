namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class Structure : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public StructureKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        public Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public Structure Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SocialPropertyId))]
        public Property SocialProperty { get; set; }
        public System.Guid? SocialPropertyId { get; set; }

        public System.Collections.Generic.List<StructureOrganizationalUnityBridge> OrganizationalUnityBridges { get; set; } = new System.Collections.Generic.List<StructureOrganizationalUnityBridge>();
    }
}
