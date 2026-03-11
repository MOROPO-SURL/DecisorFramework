namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators;

public class AcademicAchievementKnowledgeAreaBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.AcademicAchievementKnowledgeAreaBridge, Entities.AcademicAchievement, System.Guid, Entities.KnowledgeArea, System.Guid>
{
    public AcademicAchievementKnowledgeAreaBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.KnowledgeAreaBridges;
    }
}
