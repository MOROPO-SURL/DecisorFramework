namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input
{
    public class LegalBusinessKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.LegalBusinessKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.LegalBusinessKind Export()
        {
            var entity = new Persistence.Entities.LegalBusinessKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.LegalBusinessKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }

        public void Mergue(Persistence.Entities.LegalBusinessKind entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
        }
    }
}
