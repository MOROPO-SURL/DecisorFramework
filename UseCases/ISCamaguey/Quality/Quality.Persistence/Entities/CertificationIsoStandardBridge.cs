using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class CertificationIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Certification, Guid, IsoStandard, int>
    {
        public Guid ProwId { get; set; }
        
        public Certification Prow { get; set; }
        
        public int SternId { get; set; }
        
        public IsoStandard Stern { get; set; }
    }
}
