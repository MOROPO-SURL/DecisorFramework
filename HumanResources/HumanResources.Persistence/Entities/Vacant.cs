using MOROPO.Framework.Decisor.HumanResources.Persistence.Enumerations;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Vacant : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public VacantOcupationMode OcupationMode { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPositionId))]
        public WorkPosition WorkPosition { get; set; }
        public System.Guid WorkPositionId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkforceId))]
        public Workforce Workforce { get; set; }
        public System.Guid WorkforceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrganizationUnityId))]
        public Domain.Persistence.Entities.OrganizationalUnity OrganizationUnity { get; set; }
        public System.Guid OrganizationUnityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SalaryStandardId))]
        public SalaryStandard SalaryStandard { get; set; }
        public System.Guid SalaryStandardId { get; set; }
    }
}
