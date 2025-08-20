namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class VacantPostulation : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid VacantId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfficialPostalContactItemId))]
        public Guama.Identity.Persistence.Entities.PostalContactItem OfficialPostalContactItem { get; set; }
        public System.Guid OfficialPostalContactItemId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AlternativePostalContactItemId))]
        public Guama.Identity.Persistence.Entities.PostalContactItem AlternativePostalContactItem { get; set; }
        public System.Guid? AlternativePostalContactItemId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SchoolingId))]
        public Schooling Schooling { get; set; }
        public System.Guid SchoolingId { get; set; }

        public string SchoolingComplement { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string MaleParentName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string FemaleParentName { get; set; }

        public bool Alignment { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ResponsabilityCommitment { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawModelDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawModelDocument { get; set; }
        public System.Guid? RawModelDocumentId { get; set; }

        public System.Collections.Generic.ICollection<VacantPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
