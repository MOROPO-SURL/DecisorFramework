namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Input
{
    public class NaturalBusinessKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.NaturalBusinessKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.NaturalBusinessKind Export()
        {
            var entity = new Persistence.Entities.NaturalBusinessKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.NaturalBusinessKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }

        public void Mergue(Persistence.Entities.NaturalBusinessKind entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
        }
    }
}
