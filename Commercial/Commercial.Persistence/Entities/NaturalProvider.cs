namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalProvider : Contract.AbstractNaturalRelationship
    {
        public System.Collections.Generic.ICollection<NaturalProviderBankAccountBridge> BankAccountBridges { get; set; } = new System.Collections.Generic.List<NaturalProviderBankAccountBridge>();

        public System.Collections.Generic.ICollection<NaturalProviderDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<NaturalProviderDocumentBridge>();
    }
}
