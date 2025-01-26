namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ProductionPlan : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ElaborationId))]
        public Elaboration Elaboration { get; set; }
        public System.Guid ElaborationId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public System.DateTime? ApprovedAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PlannerId))]
        public HumanResources.Persistence.Entities.Employee Planner { get; set; }
        public System.Guid PlannerId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public HumanResources.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DecisorId))]
        public HumanResources.Persistence.Entities.Employee Decisor { get; set; }
        public System.Guid DecisorId { get; set; }

        public Production Production { get; set; }
    }
}

