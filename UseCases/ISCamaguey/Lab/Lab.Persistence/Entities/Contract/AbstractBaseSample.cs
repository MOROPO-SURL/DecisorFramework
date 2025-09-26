using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract
{
    public class AbstractBaseSample : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public string Observation {  get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultSampleKindId))]
        public SampleKind DefaultSampleKind { get; set; }
        public System.Guid DefaultSampleKindId { get; set; }
    }
}
