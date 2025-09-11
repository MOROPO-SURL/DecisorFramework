namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class OcupationCandidate : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime InterviewAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public VacantPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }

        public string Description { get; set; }

        public System.DateTime? MedicalCheckAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawMedicalCheckDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawMedicalCheckDocument { get; set; }
        public System.Guid? RawMedicalCheckDocumentId { get; set; }

        public System.DateTime? PhysicologicalCheckAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PhysicologicalCheckDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawPhysicologicalCheckDocument { get; set;}
        public System.Guid? PhysicologicalCheckDocumentId { get; set; }

        public System.DateTime? DefenseStatusCheckAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawDefenseStatusCheckDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawDefenseStatusCheckDocument { get; set; }
        public System.Guid? RawDefenseStatusCheckDocumentId { get; set; }

        public System.DateTime ResearchRequestAt { get; set; }

        public System.DateTime ResearchResultAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawResearchResultDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawResearchResultDocument { get; set; }
        public System.Guid? RawResearchResultDocumentId { get; set;}

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawModelDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawModelDocument { get; set; }
        public System.Guid? RawModelDocumentId { get; set; }
    }
}
