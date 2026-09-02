namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public sealed class WorkPlanServiceOrderSampleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkPlan, System.Guid, ServiceOrderSample, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public WorkPlan Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ServiceOrderSample Stern { get; set; }
    }
}
