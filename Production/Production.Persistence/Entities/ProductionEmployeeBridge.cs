namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ProductionEmployeeBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Production, System.Guid, HumanResources.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Production Prow { get; set; }

        public System.Guid SternId { get; set; }
        public HumanResources.Persistence.Entities.Employee Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StepId))]
        public ElaborationStep Step { get; set; }
        public System.Guid StepId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RoleId))]
        public ProductionRole Role { get; set; }
        public System.Guid RoleId { get; set; }
    }
}