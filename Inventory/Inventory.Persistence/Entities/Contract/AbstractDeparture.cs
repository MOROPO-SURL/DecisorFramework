using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities.Contract
{
    public class AbstractDeparture : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public HumanResources.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }

        public List<DepartureBatchBridge> BatchBridges { get; set; } = new List<DepartureBatchBridge>();
    }
}
