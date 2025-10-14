namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractLeaseOrganizationPostulation : AbstractLeasePostulation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.OrganizationContact Contact { get; set; }
        public System.Guid ContactId { get; set; }
    }
}
