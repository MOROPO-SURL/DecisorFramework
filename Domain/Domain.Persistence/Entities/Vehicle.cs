namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class Vehicle : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid FeatureImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StructureId))]
        public Structure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CategoryId))]
        public VehicleCategory Category { get; set; }
        public int CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BrandId))]
        public VehicleBrand Brand { get; set; }
        public System.Guid BrandId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Plate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string TrafficCirculationIdentifier { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string BodyIdentifier { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string EngineIdentifier { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EngineKindId))]
        public VehicleEngineKind EngineKind { get; set; }
        public System.Guid EngineKindId { get; set; }

        public string Description { get; set; }

        public int SeatCount { get; set; }

        public double LoadCapacity { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0d, 100d)]
        public double TechnicalAvailabilityIndex { get; set; }

        public System.Collections.Generic.List<VehicleImageBridge> ImageBridges { get; set; } = new System.Collections.Generic.List<VehicleImageBridge>();
    }
}
