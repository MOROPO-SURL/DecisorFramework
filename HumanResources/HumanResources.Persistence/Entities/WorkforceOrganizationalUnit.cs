namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkforceOrganizationalUnit : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkforceId))]
        public Workforce Workforce { get; set; }
        public System.Guid WorkforceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationalStructuringUnitId))]
        public Domain.Persistence.Entities.OrganizationalStructuringUnit OrganizationalStructuringUnit { get; set; }
        public System.Guid OrganizationalStructuringUnitId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefVacantId))]
        public Vacant ChiefVacant { get; set; }
        public System.Guid? ChiefVacantId { get; set; }
    }
}
