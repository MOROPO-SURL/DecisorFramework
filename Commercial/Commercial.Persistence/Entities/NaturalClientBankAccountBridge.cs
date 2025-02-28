namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClientBankAccountBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClient, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClient Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Financial.Persistence.Entities.BankAccount Stern { get; set; }
    }
}
