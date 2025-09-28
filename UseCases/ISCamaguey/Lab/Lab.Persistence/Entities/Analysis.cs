using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class Analysis : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderId))]
        public AnalysisOrder Order { get ; set ; }
        public System.Guid OrderId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TechniqueId))]
        public Technique Technique { get; set; }
        public System.Guid TechniqueId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PredecessorId))]
        public Analysis Predecessor { get; set ; }
        public System.Guid? PredecessorId { get; set ; }
    }
}
