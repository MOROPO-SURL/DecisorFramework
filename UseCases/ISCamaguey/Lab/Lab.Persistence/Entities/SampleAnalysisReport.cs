using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class SampleAnalysisReport : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        public DateTime AT {  get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisServiceReportId))]
        public SampleAnalysisServiceReport SampleAnalysisServiceReport { get; set; }
        public System.Guid SampleAnalysisServiceReportId { get; set; }

    }
}
