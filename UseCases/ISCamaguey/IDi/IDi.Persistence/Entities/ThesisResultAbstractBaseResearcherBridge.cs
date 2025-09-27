using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResultAbstractBaseResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ThesisResult, Guid, AbstractResearcher, Guid>
    {
        public Guid ProwId { get ; set ; }
        public ThesisResult Prow { get ; set ; }
        
        public Guid SternId { get ; set ; }
        public AbstractResearcher Stern { get ; set ; }
    }
}
