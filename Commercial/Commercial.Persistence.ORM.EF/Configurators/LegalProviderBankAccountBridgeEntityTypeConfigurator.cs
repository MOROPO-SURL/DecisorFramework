namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalProviderBankAccountBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalProviderBankAccountBridge, Entities.LegalProvider, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public LegalProviderBankAccountBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.BankAccountBridges;
        }
    }
}
