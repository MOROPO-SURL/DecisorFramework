using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class WarehouseInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Warehouse, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Enumerations.WharehouseKind Kind { get; set; }

        public List<WarehousingAreaInputModel> EditionAreas { get; set; } = new List<WarehousingAreaInputModel>();
        public List<WarehousingAreaInputModel> IncomingAreas { get; set; } = new List<WarehousingAreaInputModel>();
        public List<Display.WarehousingAreaDisplayModel> OutgoingAreas { get; set; } = new List<Display.WarehousingAreaDisplayModel>();

        public override Persistence.Entities.Warehouse Export()
        {
            var entity = new Persistence.Entities.Warehouse
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Warehouse entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
            entity.Kind = Kind;
        }
    }
}
