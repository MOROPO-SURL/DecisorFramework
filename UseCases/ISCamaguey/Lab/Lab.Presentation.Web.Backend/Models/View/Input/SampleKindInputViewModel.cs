namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Input
{
    public class SampleKindInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.SampleKind, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public bool Enabled { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.SampleKind Export()
        {
            var entity = new Persistence.Entities.SampleKind { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.SampleKind entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.SampleKind entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
