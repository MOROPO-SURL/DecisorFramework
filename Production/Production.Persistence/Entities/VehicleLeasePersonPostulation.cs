namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class VehicleLeasePersonPostulation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OfferId))]
        public VehicleLeaseOffer Offer { get; set; }
        public System.Guid OfferId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public Domain.Persistence.Entities.NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeasePersonPostulationDocumentBridge> DocumentBridges { get; set; }
    }
}
