namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalClientBankAccountBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalClient, System.Guid, Financial.Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalClient Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Financial.Persistence.Entities.BankAccount Stern { get; set; }
    }
}
