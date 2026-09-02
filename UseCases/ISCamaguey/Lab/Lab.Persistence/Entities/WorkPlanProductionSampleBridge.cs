namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public sealed class WorkPlanProductionSampleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkPlan, System.Guid, ProductionSample, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public WorkPlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ProductionSample Stern { get; set; }
    }
}
