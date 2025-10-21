namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class FinancierResearchAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.FinancierResearchAreaBridge, Entities.Financier, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public FinancierResearchAreaBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaBridges;
        }
    }
}
