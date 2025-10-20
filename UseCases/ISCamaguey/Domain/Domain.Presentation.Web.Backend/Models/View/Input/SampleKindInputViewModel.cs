using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Backend.Models.View.Input
{
    public class SampleKindInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<SampleKind, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public bool Enabled { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public SampleKind Export()
        {
            var entity = new SampleKind();

            Mergue(entity);

            return entity;
        }

        public void Import(SampleKind entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(SampleKind entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
