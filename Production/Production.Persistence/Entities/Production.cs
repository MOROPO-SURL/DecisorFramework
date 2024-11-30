using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class Production : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PlanId))]
        public ProductionPlan Plan { get; set; }
        public System.Guid PlanId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }

        public string Description { get; set; }

        public List<ProductionProductBridge> ProductBridges { get; set; } = new List<ProductionProductBridge>();

        public List<ProductionEmployeeBridge> EmployeeBridges { get; set; } = new List<ProductionEmployeeBridge>();

        public List<ProductionColaboratorBridge> ColaboratorBridges { get; set; } = new List<ProductionColaboratorBridge>();
    }
}
