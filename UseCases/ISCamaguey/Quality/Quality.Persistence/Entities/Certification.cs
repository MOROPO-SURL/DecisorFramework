using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class Certification : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
        
        public bool Archived { get; set; }
        
        public bool Enabled { get; set; }
        
        public int Priority { get; set; }

        public System.Collections.Generic.List<CertificationCubanStandardBridge> CubanStandardBridges { get; set; } = new System.Collections.Generic.List<CertificationCubanStandardBridge>();

        public System.Collections.Generic.List<CertificationIsoStandardBridge> IsoStandardBridges { get; set; } = new System.Collections.Generic.List<CertificationIsoStandardBridge>();
        
    }
}
