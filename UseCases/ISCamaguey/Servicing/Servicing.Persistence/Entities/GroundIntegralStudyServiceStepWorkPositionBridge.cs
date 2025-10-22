namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class GroundIntegralStudyServiceStepWorkPositionBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<GroundIntegralStudyServiceStep, System.Guid, Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public GroundIntegralStudyServiceStep Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition Stern { get; set; }

        public int Priority { get; set; }

        public decimal RequiredTimingEffort { get; set; }

        public decimal FixedParticipation { get; set; }

        public decimal RelativeParticipation { get; set; }

        public string Description { get; set; }
    }
}
