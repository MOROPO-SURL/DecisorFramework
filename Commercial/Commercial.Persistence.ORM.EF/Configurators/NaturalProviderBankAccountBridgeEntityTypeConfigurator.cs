namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderBankAccountBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalProviderBankAccountBridge, Entities.NaturalProvider, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public NaturalProviderBankAccountBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.BankAccountBridges;
        }
    }
}
