using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public class AbstractBaseSampleAnalysisServiceOrder : AbstractBaseServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisServiceReportId))]
        public SampleAnalysisServiceReport SampleAnalysisServiceReport { get; set; }
        public System.Guid SampleAnalysisServiceReportId { get; set;}

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RequestedTechniqueId))]
        public Technique RequestedTechnique { get; set; }
        public System.Guid? RequestedTechniqueId { get; set;}
    }
}
