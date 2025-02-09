namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class WarehousingArea : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
        public System.Guid WarehouseId { get; set; }

        public double Capacity { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FamilyId))]
        public Family Family { get; set; }
        public int FamilyId { get; set; }

        public string Description { get; set; }
    }
}
