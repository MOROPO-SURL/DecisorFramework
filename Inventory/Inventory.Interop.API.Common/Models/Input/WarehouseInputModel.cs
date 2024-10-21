namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class WarehouseInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Warehouse, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.Warehouse Export()
        {
            var entity = new Persistence.Entities.Warehouse
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Warehouse entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Warehouse entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
