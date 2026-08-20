namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class AcademicAchievement : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        public Enumerations.AcademicLevel AcademicLevel { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MainKnowledgeAreaId))]
        public KnowledgeArea MainKnowledgeArea { get; set; }
        public System.Guid MainKnowledgeAreaId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string Title { get; set; }

        public System.DateTime? At { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string Institution { get; set; }

        public System.Collections.Generic.List<AcademicAchievementKnowledgeAreaBridge> KnowledgeAreaBridges { get; set; } = new System.Collections.Generic.List<AcademicAchievementKnowledgeAreaBridge>();
    }
}