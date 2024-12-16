namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input
{
    public class StructureKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.StructureKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.StructureKind Export()
        {
            var entity = new Persistence.Entities.StructureKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.StructureKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.StructureKind entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}
