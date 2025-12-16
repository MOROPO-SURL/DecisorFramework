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

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductId))]
        public Inventory.Persistence.Entities.Product Product { get; set; }
        public System.Guid ProductId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClassificcationId))]
        public Inventory.Persistence.Entities.Classification Classification { get; set; }
        public System.Guid? ClassificcationId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public decimal MinPerformanceCoefficient { get; set; }

        public decimal MaxPerformanceCoefficient { get; set; }

        public System.Collections.ObjectModel.Collection<ElaborationStep> Steps { get; set; }

        public List<ElaborationInputProductBridge> InputProductBridges { get; set; } = new List<ElaborationInputProductBridge>();

        public List<ElaborationInputProductClassificationBridge> InputProductClassificationBridges { get; set; } = new List<ElaborationInputProductClassificationBridge>();

        public List<ElaborationOutputProductBridge> OutputProductBridges { get; set; } = new List<ElaborationOutputProductBridge>();

        public List<ElaborationOutputProductClassificationBridge> OutputProductClassificationBridges { get; set; } = new List<ElaborationOutputProductClassificationBridge>();
    }
}