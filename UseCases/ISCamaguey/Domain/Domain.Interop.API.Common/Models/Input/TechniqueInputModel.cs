using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class TechniqueInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Technique, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel[] CubanStandards { get; set; }

        public Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel[] IsoStandards { get; set; }

        public override Persistence.Entities.Technique Export()
        {
            var entity = new Persistence.Entities.Technique { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Technique entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;

            entity.CubanStandardBridge.Clear();
            entity.CubanStandardBridge = CubanStandards.Select(model => new Persistence.Entities.TechniqueCubanStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.IsoStandardBridge.Clear();
            entity.IsoStandardBridge = IsoStandards.Select(model => new Persistence.Entities.TechniqueIsoStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
