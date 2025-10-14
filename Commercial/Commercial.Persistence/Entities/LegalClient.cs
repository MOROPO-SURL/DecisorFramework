namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalClient : Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.List<LegalClientBankAccountBridge> BankAccountBridges { get; set; } = new System.Collections.Generic.List<LegalClientBankAccountBridge>();

        public System.Collections.Generic.List<LegalClientDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<LegalClientDocumentBridge>();
    }
}