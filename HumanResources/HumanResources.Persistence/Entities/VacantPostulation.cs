namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class VacantPostulation : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public System.Guid StaffId { get; set; }

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

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(256)]
        public string UltimateEducationInstitution { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string TitulationTitle { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(200)]
        public string MaleParentName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(200)]
        public string FemaleParentName { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(256)]
        public string Alignment { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(1024)]
        public string ResponsabilityCommitment { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawModelDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawModelDocument { get; set; }
        public System.Guid? RawModelDocumentId { get; set; }

        public System.Collections.Generic.ICollection<VacantPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
