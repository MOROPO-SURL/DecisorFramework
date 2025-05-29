namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalProvider : Contract.AbstractNaturalRelationship
    {
        public System.Collections.Generic.ICollection<NaturalProviderBankAccountBridge> BankAccountBridges { get; set; }

        public System.Collections.Generic.ICollection<NaturalProviderDocumentBridge> DocumentBridges { get; set; }
    }
}
