using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResult : Contract.AbstractBaseResult
    {
        public System.Collections.Generic.List<TrainingResultAbstractBaseResearcherBridge> AbstractBaseResearcherBridges { get; set; } = new System.Collections.Generic.List<TrainingResultAbstractBaseResearcherBridge>();
    }
}
