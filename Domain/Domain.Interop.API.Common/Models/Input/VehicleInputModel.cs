using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class VehicleInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Vehicle, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.Guid BrandId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Model { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public System.Guid KindId { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Plate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string TrafficCirculationIdentifier { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string BodyIdentifier { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string EngineIdentifier { get; set; }

        public System.Guid EngineKindId { get; set; }

        public string Description { get; set; }

        public int SeatCount { get; set; }

        public double LoadCapacity { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0d, 100d)]
        public double TechnicalAvailabilityIndex { get; set; }

        public List<ImageInputModel> IncomingImageItems { get; set; } = new List<ImageInputModel>();
        public List<ImageDisplayModel> OutgoingImagetItems { get; set; } = new List<ImageDisplayModel>();

        public Persistence.Entities.Vehicle Export()
        {
            var entity = new Persistence.Entities.Vehicle { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Vehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Vehicle entity)
        {
            entity.Priority = Priority;
            entity.Model = Model;
            entity.Reference = Reference;
            entity.Model = Model;
            entity.Year = Year;
            entity.Plate = Plate;
            entity.TrafficCirculationIdentifier = TrafficCirculationIdentifier;
            entity.BodyIdentifier = BodyIdentifier;
            entity.EngineIdentifier = EngineIdentifier;
            entity.Description = Description;
            entity.SeatCount = SeatCount;
            entity.LoadCapacity = LoadCapacity;
            entity.TechnicalAvailabilityIndex = TechnicalAvailabilityIndex;

            if (entity.BrandId != BrandId)
            {
                entity.Brand = null;
                entity.BrandId = BrandId;
            }

            if (entity.StructureId != StructureId)
            {
                entity.Structure = null;
                entity.StructureId = StructureId;
            }

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.EngineKindId != EngineKindId)
            {
                entity.EngineKind = null;
                entity.EngineKindId = EngineKindId;
            }
        }
    }
}
