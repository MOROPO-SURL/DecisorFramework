namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display
{
    public class WarehousingAreaDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WarehousingArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public WarehouseDisplayModel Warehouse { get; set; }

        public double Capacity { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public FamilyDisplayModel Family { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.WarehousingArea entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Capacity = entity.Capacity;
            Description = entity.Description;

            if (entity.Warehouse != null)
            {
                Warehouse = new WarehouseDisplayModel();

                Warehouse.Import(entity.Warehouse);
            }

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }

            if (entity.Family != null)
            {
                Family = new FamilyDisplayModel();

                Family.Import(entity.Family);
            }
        }
    }
}
