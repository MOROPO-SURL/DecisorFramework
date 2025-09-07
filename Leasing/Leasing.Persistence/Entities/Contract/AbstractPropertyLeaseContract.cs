namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractPropertyLeaseContract : AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyId))]
        public Domain.Persistence.Entities.Property Property { get; set; }
        public System.Guid PropertyId { get; set; }
    }
}