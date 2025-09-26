using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class ServiceOrderSample : Contract.AbstractBaseSample
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstractBaseSampleAnalysisServiceOrderId))]
        public AbstractBaseSampleAnalysisServiceOrder AbstractBaseSampleAnalysisServiceOrder { get; set; }
        public long AbstractBaseSampleAnalysisServiceOrderId { get; set; }
    }
}
