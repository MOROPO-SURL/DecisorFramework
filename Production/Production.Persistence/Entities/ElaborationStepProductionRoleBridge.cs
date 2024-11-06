namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationStepProductionRoleBridge : Guama.Core.Persistence.Entities.Contract.IBridge<ElaborationStep, System.Guid, ProductionRole, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ElaborationStep Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ProductionRole Stern { get; set; }

        public decimal Participation { get; set; }

        public bool Linked { get; set; }

        public string Description { get; set; }
    }
}

