using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResultAbstractBaseResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingResult, Guid, AbstractResearcher, Guid>
    {
        public Guid ProwId { get ; set ; }
        public TrainingResult Prow { get ; set ; }
        
        public Guid SternId { get ; set ; }
        public AbstractResearcher Stern { get ; set ; }
    }
}
