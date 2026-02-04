namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class DriveLicence : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Code { get; set; } // Number

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Reference { get; set; } // Document id (reverso ej: C577490)

        public System.DateTime ReleasedAt { get; set; }

        public System.DateTime ExpireAt { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Limitation { get; set; }

        public System.Collections.Generic.List<DriveLicenceVehicleKindBridge> VehicleKindBridges { get; set; } = new System.Collections.Generic.List<DriveLicenceVehicleKindBridge>();
    }
}