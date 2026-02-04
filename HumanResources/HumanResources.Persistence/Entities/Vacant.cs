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

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkforceOrganizationalUnityId))]
        public WorkforceOrganizationalUnity WorkforceOrganizationalUnity { get; set; }
        public System.Guid? WorkforceOrganizationalUnityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SalaryStandardId))]
        public SalaryStandard SalaryStandard { get; set; }
        public System.Guid SalaryStandardId { get; set; }
    }
}
