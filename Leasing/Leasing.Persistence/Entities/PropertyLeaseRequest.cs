namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseRequest : Contract.AbstractLeaseRequest
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyId))]
        public Domain.Persistence.Entities.Property Property { get; set; }
        public System.Guid PropertyId { get; set; }
    }
}
