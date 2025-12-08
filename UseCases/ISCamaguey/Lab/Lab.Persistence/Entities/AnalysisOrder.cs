namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class AnalysisOrder : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }

        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPlanId))]
        public WorkPlan WorkPlan { get ; set ; }
        public System.Guid? WorkPlanId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleId))]
        public Contract.AbstractSample Sample { get; set ; }
        public System.Guid SampleId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TechniqueId))]
        public Domain.Persistence.Entities.Technique Technique { get; set ; }
        public System.Guid TechniqueId { get; set; }
    }
}
