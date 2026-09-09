using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class ProjectSpecificObjectiveDisplayModel : IEntityDisplayModel<ProjectSpecificObjective, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Import(ProjectSpecificObjective entity)
        {
            Id = entity.Id;
            Index = entity.Index;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
