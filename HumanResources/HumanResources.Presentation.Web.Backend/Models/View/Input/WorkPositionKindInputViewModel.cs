namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Models.View.Input
{
    public class WorkPositionKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.WorkPositionKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.WorkPositionKind Export()
        {
            var entity = new Persistence.Entities.WorkPositionKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.WorkPositionKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ShortName = entity.ShortName;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.WorkPositionKind entity)
        {
            entity.Name = Name;
            entity.ShortName = ShortName;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}
