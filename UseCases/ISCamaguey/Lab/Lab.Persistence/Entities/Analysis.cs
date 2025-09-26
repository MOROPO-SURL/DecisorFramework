using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class Analysis : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        public DateTime AT {  get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderOfAnalysisId))]
        public OrderOfAnalysis OrderOfAnalysis { get ; set ; }
        public System.Guid OrderOfAnalysisId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RepeatAnalysisId))]
        public Analysis RepeatAnalysis { get; set ; }
        public System.Guid? RepeatAnalysisId { get; set ; }

    }
}
