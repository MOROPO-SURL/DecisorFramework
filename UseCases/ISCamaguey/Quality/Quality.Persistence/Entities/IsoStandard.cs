using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class IsoStandard : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<int>,Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Archived { get; set; }
        
        public bool Enabled { get; set; }
        
        public int Priority { get; set; }
        
        
    }
}
