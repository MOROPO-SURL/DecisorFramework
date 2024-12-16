namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Input
{
    public class VehicleEngineKindInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VehicleEngineKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.VehicleEngineKind Export()
        {
            var entity = new Persistence.Entities.VehicleEngineKind();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VehicleEngineKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.VehicleEngineKind entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}
