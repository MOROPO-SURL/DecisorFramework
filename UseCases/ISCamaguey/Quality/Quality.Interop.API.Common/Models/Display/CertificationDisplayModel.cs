
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using System;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display
{
    public class CertificationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Certification, System.Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public CubanStandardDisplayModel[] CubanStandards { get; set; }

        public IsoStandardDisplayModel[] IsoStandards { get; set; }

        public virtual void Import(Certification entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Created = entity.Created;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            CubanStandards = entity.CubanStandardBridges.Select(bridge =>
            {
                var model = new CubanStandardDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            IsoStandards = entity.IsoStandardBridges.Select(bridge =>
            {
                var model = new Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray(); 
        }
    }
}
