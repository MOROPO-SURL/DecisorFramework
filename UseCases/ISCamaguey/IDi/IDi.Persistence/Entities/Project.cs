using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class Project : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectReportId))]
        public ProjectReport ProjectReport { get; set; }
        public System.Guid ProjectReportId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstractBaseResearcherId))]
        public AbstractResearcher AbstractBaseResearcher { get; set; }
        public System.Guid AbstractBaseResearcherId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ReferenceId))]
        public Project Reference { get; set; }
        public System.Guid? ReferenceId { get; set; }

        public System.Collections.Generic.List<ProjectFinancierBridge> FinancierBridges {  get; set; } = new System.Collections.Generic.List<ProjectFinancierBridge>();

        public System.Collections.Generic.List<ProjectParticipatingEntityBridge> ParticipatingEntityBridges { get; set; } = new System.Collections.Generic.List<ProjectParticipatingEntityBridge>();

        public System.Collections.Generic.List<ProjectAbstractBaseResearcherBridge> AbstractBaseResearcherBridges { get; set; } = new System.Collections.Generic.List<ProjectAbstractBaseResearcherBridge>();

    }
}
