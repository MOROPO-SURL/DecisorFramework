namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractLeasePersonPostulation : AbstractLeasePostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }
    }
}
