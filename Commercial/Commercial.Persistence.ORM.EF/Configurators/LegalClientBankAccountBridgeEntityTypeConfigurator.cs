namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalClientBankAccountBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientBankAccountBridge, Entities.LegalClient, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public LegalClientBankAccountBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.BankAccountBridges;
        }
    }
}
