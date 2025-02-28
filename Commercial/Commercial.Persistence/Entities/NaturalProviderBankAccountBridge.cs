namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalProviderBankAccountBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalProvider, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalProvider Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Financial.Persistence.Entities.BankAccount Stern { get; set; }
    }
}
