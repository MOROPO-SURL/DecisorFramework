using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ScientificTechnicalResultKindInputModel : IEntityInputModel<ScientificTechnicalResultKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ScientificTechnicalResultKind Export()
        {
            var entity = new ScientificTechnicalResultKind { Id = Id, Enabled = true, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(ScientificTechnicalResultKind entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ScientificTechnicalResultKind entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
