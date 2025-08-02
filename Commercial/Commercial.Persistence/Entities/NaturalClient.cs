namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClient : Contract.AbstractNaturalRelationship
    {
        public System.Collections.Generic.ICollection<NaturalClientBankAccountBridge> BankAccountBridges { get; set; } = new System.Collections.Generic.List<NaturalClientBankAccountBridge>();

        public System.Collections.Generic.ICollection<NaturalClientDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<NaturalClientDocumentBridge>();
    }
}
