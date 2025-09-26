using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, IsoStandard, int>
    {
        public Guid ProwId { get; set; }
        public Technique Prow { get; set; }
        
        public int SternId { get; set; }
        public IsoStandard Stern { get; set; }
    }
}
