namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Input
{
    public class ProductionRoleInputViewModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ProductionRole, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.ProductionRole Export()
        {
            var entity = new Persistence.Entities.ProductionRole();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ProductionRole entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }

        public void Mergue(Persistence.Entities.ProductionRole entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Enabled = Enabled;
            entity.Priority = Priority;
        }
    }
}

