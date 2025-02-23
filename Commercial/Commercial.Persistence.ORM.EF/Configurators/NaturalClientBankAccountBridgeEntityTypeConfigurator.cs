namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalClientBankAccountBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientBankAccountBridge, Entities.NaturalClient, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public NaturalClientBankAccountBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.BankAccountBridges;
        }
    }
}