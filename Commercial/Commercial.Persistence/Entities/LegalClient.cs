namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalClient : Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.ICollection<LegalClientBankAccountBridge> BankAccountBridges { get; set; }
    }
}

