using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class CertificationCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Certification, Guid, CubanStandard, int>
    {
        public Guid ProwId { get; set; }
        
        public Certification Prow { get; set; }
        
        public int SternId { get; set; }
        
        public CubanStandard Stern { get; set; }
    }
}
