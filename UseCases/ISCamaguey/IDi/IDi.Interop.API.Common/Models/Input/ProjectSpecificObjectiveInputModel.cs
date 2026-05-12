using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ProjectSpecificObjectiveInputModel : IEntityInputModel<ProjectSpecificObjective, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(2550)]
        public string Description { get; set; }

        public ProjectSpecificObjective Export()
        {
            ProjectSpecificObjective entity = new ProjectSpecificObjective { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectSpecificObjective entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ProjectSpecificObjective entity)
        {
            entity.Index = Index;
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
