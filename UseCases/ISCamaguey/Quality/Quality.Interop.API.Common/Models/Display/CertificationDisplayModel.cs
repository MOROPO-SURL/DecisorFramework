
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using System;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display
{
    public class CertificationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Certification, System.Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public bool Enable { get; set; }

        public int Priority { get; set; }

        public void Import(Certification entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Created = entity.Created;
            Enable = entity.Enabled;
            Priority = entity.Priority;
        }
    }
}
