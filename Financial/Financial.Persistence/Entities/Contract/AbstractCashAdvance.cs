namespace MOROPO.Framework.Decisor.Financial.Persistence.Entities.Contract
{
    public abstract class AbstractCashAdvance : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public decimal Amount { get; set; }
    }
}
