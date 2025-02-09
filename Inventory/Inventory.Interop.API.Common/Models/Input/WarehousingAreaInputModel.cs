namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class WarehousingAreaInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.WarehousingArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.Guid WarehouseId { get; set; }

        public double Capacity { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public int FamilyId { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.WarehousingArea Export()
        {
            var entity = new Persistence.Entities.WarehousingArea { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.WarehousingArea entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.WarehousingArea entity)
        {
            entity.Name = Name;
            entity.Capacity = Capacity;
            entity.Description = Description;

            if (entity.WarehouseId != WarehouseId)
            {
                entity.Warehouse = null;
                entity.WarehouseId = WarehouseId;
            }

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }

            if (entity.FamilyId != FamilyId)
            {
                entity.Family = null;
                entity.FamilyId = FamilyId;
            }
        }
    }
}
