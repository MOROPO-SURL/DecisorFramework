namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalProvider : Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.List<LegalProviderBankAccountBridge> BankAccountBridges { get; set; } = new System.Collections.Generic.List<LegalProviderBankAccountBridge>();

        public System.Collections.Generic.List<LegalProviderDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<LegalProviderDocumentBridge>();
    }
}