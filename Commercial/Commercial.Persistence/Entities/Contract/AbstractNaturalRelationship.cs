namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public abstract class AbstractNaturalRelationship : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultPaymentTermId))]
        public PaymentTerm DefaultPaymentTerm { get; set; }
        public System.Guid DefaultPaymentTermId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public Domain.Persistence.Entities.NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid? BusinessKindId { get; set; }
    }
}

