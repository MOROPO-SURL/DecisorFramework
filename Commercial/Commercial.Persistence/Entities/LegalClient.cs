namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalClient : Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.ICollection<LegalClientBankAccountBridge> BankAccountBridges { get; set; }

        public System.Collections.Generic.ICollection<LegalClientDocumentBridge> DocumentBridges { get; set; }
    }
}

