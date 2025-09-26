using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class OrderOfAnalysis : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPlanId))]
        public WorkPlan WorkPlan { get ; set ; }
        public System.Guid WorkPlanId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisReportId))]
        public SampleAnalysisReport SampleAnalysisReport { get; set ; }
        public System.Guid SampleAnalysisReportId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstractBaseSampleId))]
        public AbstractBaseSample AbstractBaseSample { get; set ; }
        public System.Guid AbstractBaseSampleId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TechniqueId))]
        public Technique Technique { get; set ; }
        public System.Guid TechniqueId { get; set; }
    }
}
