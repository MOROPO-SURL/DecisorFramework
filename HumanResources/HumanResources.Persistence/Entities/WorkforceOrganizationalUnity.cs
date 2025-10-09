namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkforceOrganizationalUnity : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkforceId))]
        public Workforce Workforce { get; set; }
        public System.Guid WorkforceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationalUnityId))]
        public Domain.Persistence.Entities.OrganizationalUnity OrganizationalUnity { get; set; }
        public System.Guid OrganizationalUnityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefVacantId))]
        public Vacant ChiefVacant { get; set; }
        public System.Guid? ChiefVacantId { get; set; }

        public WorkforceOrganizationalUnity Parent { get; set; }
        public System.Guid? ParentId { get; set; }
    }
}
