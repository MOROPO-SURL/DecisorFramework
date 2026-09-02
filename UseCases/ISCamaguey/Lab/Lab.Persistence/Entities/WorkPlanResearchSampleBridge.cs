namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public sealed class WorkPlanResearchSampleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkPlan, System.Guid, ResearchSample, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public WorkPlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ResearchSample Stern { get; set; }
    }
}