using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class Elaboration : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Inventory.Persistence.Entities.Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        public string Description { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        public System.Collections.ObjectModel.Collection<ElaborationStep> Steps { get; set; }

        public List<ElaborationInputProductBridge> InputProductBridges { get; set; } = new List<ElaborationInputProductBridge>();

        public List<ElaborationOutputProductBridge> OutputProductBridges { get; set; } = new List<ElaborationOutputProductBridge>();
    }
}
