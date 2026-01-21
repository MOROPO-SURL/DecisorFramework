using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class VehicleDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Vehicle, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Persistence.Enumerations.VehicleAssignment? Assignment { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public StructureParentalDisplayModel Structure { get; set; }

        public string Reference { get; set; }

        public string OperativeLicenceCode { get; set; }

        public VehicleKindDisplayModel Kind { get; set; }

        public BrandDisplayModel Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Plate { get; set; }

        public string TrafficCirculationIdentifier { get; set; }

        public string BodyIdentifier { get; set; }

        public string EngineIdentifier { get; set; }

        public VehicleEngineKindDisplayModel EngineKind { get; set; }

        public int SeatCount { get; set; }

        public double LoadCapacity { get; set; }

        public double TechnicalAvailabilityIndex { get; set; }

        public string Description { get; set; }

        public ImageDisplayModel[] Images { get; set; }

        public void Import(Persistence.Entities.Vehicle entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Assignment = entity.Assignment;
            Reference = entity.Reference;
            OperativeLicenceCode = entity.OperativeLicenceCode;
            Model = entity.Model;
            Year = entity.Year;
            Plate = entity.Plate;
            TrafficCirculationIdentifier = entity.TrafficCirculationIdentifier;
            BodyIdentifier = entity.BodyIdentifier;
            EngineIdentifier = entity.EngineIdentifier;
            SeatCount = entity.SeatCount;
            LoadCapacity = entity.LoadCapacity;
            TechnicalAvailabilityIndex = entity.TechnicalAvailabilityIndex;
            Description = entity.Description;

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }

            if (entity.Kind != null)
            {
                Kind = new VehicleKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Brand != null)
            {
                Brand = new BrandDisplayModel();

                Brand.Import(entity.Brand);
            }

            if (entity.EngineKind != null)
            {
                EngineKind = new VehicleEngineKindDisplayModel();

                EngineKind.Import(entity.EngineKind);
            }

            if (entity.Structure != null)
            {
                Structure = new StructureParentalDisplayModel();

                Structure.Import(entity.Structure);
            }
        }
    }
}
