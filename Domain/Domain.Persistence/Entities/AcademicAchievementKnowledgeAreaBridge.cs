namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class AcademicAchievementKnowledgeAreaBridge : Guama.Core.Persistence.Entities.Contract.IBridge<AcademicAchievement, System.Guid, KnowledgeArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public AcademicAchievement Prow { get; set; }

        public System.Guid SternId { get; set; }
        public KnowledgeArea Stern { get; set; }
    }
}
