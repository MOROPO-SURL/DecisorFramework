using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, CubanStandard, int>
    {
        public Guid ProwId { get ; set ; }
        public Technique Prow { get ; set ; }
        
        public int SternId { get ; set ; }
        public CubanStandard Stern { get ; set ; }
    }
}
