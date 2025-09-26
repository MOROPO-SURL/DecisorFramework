using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkPlan : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        public DateTime AT {  get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }
        
    }
}
