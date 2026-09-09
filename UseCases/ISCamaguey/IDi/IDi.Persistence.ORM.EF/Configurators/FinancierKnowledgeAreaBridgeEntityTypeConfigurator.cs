namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class FinancierKnowledgeAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.FinancierKnowledgeAreaBridge, Entities.Financier, System.Guid, Framework.Decisor.Domain.Persistence.Entities.KnowledgeArea, System.Guid>
{
    public FinancierKnowledgeAreaBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.KnowledgeAreaBridges;
    }
}
