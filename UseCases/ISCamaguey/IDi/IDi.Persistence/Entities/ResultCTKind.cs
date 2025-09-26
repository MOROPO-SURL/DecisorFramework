using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ResultCTKind : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ScientificTechnicalAchievementResultId))]
        public ScientificTechnicalAchievementResult ScientificTechnicalAchievementResult { get ; set ; }
        public System.Guid ScientificTechnicalAchievementResultId { get ; set ; }


    }
}
