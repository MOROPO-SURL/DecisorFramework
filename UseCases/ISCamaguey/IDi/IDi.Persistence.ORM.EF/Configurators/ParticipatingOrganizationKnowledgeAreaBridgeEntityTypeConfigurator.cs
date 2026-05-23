namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class ParticipatingOrganizationKnowledgeAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ParticipatingOrganizationKnowledgeAreaBridge, Entities.ParticipatingOrganization, System.Guid, Framework.Decisor.Domain.Persistence.Entities.KnowledgeArea, System.Guid>
{
    public ParticipatingOrganizationKnowledgeAreaBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.KnowledgeAreaBridges;
    }
}
