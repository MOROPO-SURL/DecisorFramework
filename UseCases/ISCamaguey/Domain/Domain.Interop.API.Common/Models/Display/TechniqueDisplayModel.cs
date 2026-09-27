using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class TechniqueDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Technique, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel[] CubanStandards { get; set; }

        public Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel[] IsoStandards { get; set; }

        public virtual void Import(Persistence.Entities.Technique entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            CubanStandards = entity.CubanStandardBridge.Select(bridge =>
            {
                var model = new Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            IsoStandards = entity.IsoStandardBridge.Select(bridge =>
            {
                var model = new Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
