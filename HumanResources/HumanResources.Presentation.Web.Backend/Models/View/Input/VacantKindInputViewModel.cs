namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Input
{
    public class VacantKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VacantKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.VacantKind Export()
        {
            var entity = new Persistence.Entities.VacantKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VacantKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ShortName = entity.ShortName;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.VacantKind entity)
        {
            entity.Name = Name;
            entity.ShortName = ShortName;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}
