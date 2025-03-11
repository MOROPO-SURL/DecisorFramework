namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ProductionColaboratorBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Production, System.Guid, Essential.Persistence.Entities.Colaborator, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Production Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Essential.Persistence.Entities.Colaborator Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StepId))]
        public ElaborationStep Step { get; set; }
        public System.Guid StepId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPositionId))]
        public HumanResources.Persistence.Entities.WorkPosition WorkPosition { get; set; }
        public System.Guid WorkPositionId { get; set; }
    }
}