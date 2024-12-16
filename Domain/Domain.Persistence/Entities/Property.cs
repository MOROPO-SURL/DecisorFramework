namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class Property : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public PropertyKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostalContactId))]
        public Guama.Identity.Persistence.Entities.PostalContactItem PostalContact { get; set; }
        public System.Guid PostalContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid FeatureImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StructureId))]
        public Structure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string PropertyRecordIdentifier { get; set; }

        public decimal Area { get; set; }

        public string Description { get; set; }

        public System.Collections.Generic.List<PropertyImageBridge> ImageBridges { get; set; } = new System.Collections.Generic.List<PropertyImageBridge>();
    }
}
