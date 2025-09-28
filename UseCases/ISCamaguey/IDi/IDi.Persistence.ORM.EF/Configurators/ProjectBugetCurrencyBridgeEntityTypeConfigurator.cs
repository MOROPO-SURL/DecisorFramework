namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProjectBugetCurrencyBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProjectBudgetCurrencyBridge, Entities.Project, System.Guid, Framework.Decisor.Financial.Persistence.Entities.Currency, System.Guid>
    {
        public ProjectBugetCurrencyBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.BudgetCurrencyBridges;
        }
    }
}
