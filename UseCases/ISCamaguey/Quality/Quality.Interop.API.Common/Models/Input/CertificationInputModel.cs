using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class CertificationInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Certification, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime Created { get; set; }

        public int Priority { get; set; }

        public System.Collections.Generic.List<Display.CubanStandardDisplayModel> CubanStandards { get; set; } = new System.Collections.Generic.List<Display.CubanStandardDisplayModel>();

        public System.Collections.Generic.List<Display.IsoStandardDisplayModel> IsoStandards { get; set; } = new System.Collections.Generic.List<Display.IsoStandardDisplayModel>();

        public override Persistence.Entities.Certification Export()
        {
            var entity = new Persistence.Entities.Certification { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Certification entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
            entity.Created = Created;

            entity.CubanStandardBridges.Clear();
            entity.CubanStandardBridges = CubanStandards.Select(model => new Persistence.Entities.CertificationCubanStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.IsoStandardBridges.Clear();
            entity.IsoStandardBridges = IsoStandards.Select(model => new Persistence.Entities.CertificationIsoStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
