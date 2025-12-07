using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract
{
    public abstract class AbstractResearcher : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CategoryId))]
        public ResearcherCategory Category { get ; set ; }
        public System.Guid? CategoryId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TeachingCategoryId))]
        public TeachingCategory TeachingCategory { get; set; }
        public System.Guid? TeachingCategoryId { get; set; }

        public int TimeAvailability { get; set; }

        public List<ResearcherResearchAreaSpecializationBridge> ResearchAreaSpecializationBridges { get; set; } = new List<ResearcherResearchAreaSpecializationBridge>();

        public List<ResearcherResearchAreaMasteryBridge> ResearchAreaMasteryBridges { get; set; } = new List<ResearcherResearchAreaMasteryBridge>();

        public List<ResearcherResearchAreaDoctorateBridge> ResearchAreaDoctorateBridges { get; set; } = new List<ResearcherResearchAreaDoctorateBridge>();
    }
}
