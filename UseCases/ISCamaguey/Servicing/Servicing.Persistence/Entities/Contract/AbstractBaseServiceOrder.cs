using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public class AbstractBaseServiceOrder : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public DateTime AT {  get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }
        
    }
}
