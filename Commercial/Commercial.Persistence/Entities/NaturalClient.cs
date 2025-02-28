namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClient : Contract.AbstractNaturalRelationship
    {
        public System.Collections.Generic.ICollection<NaturalClientBankAccountBridge> BankAccountBridges { get; set; }
    }
}
