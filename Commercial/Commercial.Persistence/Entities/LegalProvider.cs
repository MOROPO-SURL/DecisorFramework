namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalProvider : Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.ICollection<LegalProviderBankAccountBridge> BankAccountBridges { get; set; }
    }
}