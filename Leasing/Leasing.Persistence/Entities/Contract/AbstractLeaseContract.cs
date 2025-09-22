namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractLeaseContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        public double Feed { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PaymentTermId))]
        public Commercial.Persistence.Entities.PaymentTerm PaymentTerm { get; set; }
        public System.Guid PaymentTermId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BankAccountId))]
        public Financial.Persistence.Entities.BankAccount BankAccount { get; set; }
        public System.Guid BankAccountId { get; set; }
    }
}