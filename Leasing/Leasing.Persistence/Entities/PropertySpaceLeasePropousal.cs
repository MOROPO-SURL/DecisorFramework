namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertySpaceLeasePropousal : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyLeasePropousalId))]
        public PropertyLeasePropousal PropertyLeasePropousal { get; set; }
        public System.Guid PropertyLeasePropousalId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertySpaceId))]
        public Domain.Persistence.Entities.PropertySpace PropertySpace { get; set; }
        public System.Guid PropertySpaceId { get; set; }

        public string Argument { get; set; }
    }
}
