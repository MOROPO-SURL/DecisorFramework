namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalProviderBankAccountBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalProvider, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalProvider Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Financial.Persistence.Entities.BankAccount Stern { get; set; }
    }
}
