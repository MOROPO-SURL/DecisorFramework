namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationStepWorkPositionBridge : Guama.Core.Persistence.Entities.Contract.IBridge<ElaborationStep, System.Guid, HumanResources.Persistence.Entities.WorkPosition, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ElaborationStep Prow { get; set; }

        public System.Guid SternId { get; set; }
        public HumanResources.Persistence.Entities.WorkPosition Stern { get; set; }

        public decimal Participation { get; set; }

        public bool Linked { get; set; }

        public string Description { get; set; }
    }
}

