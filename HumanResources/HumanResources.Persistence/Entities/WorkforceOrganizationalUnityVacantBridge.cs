namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkforceOrganizationalUnityVacantBridge
    {
        public System.Guid WorkforceId { get; set; }
        public Workforce Workforce { get; set; }

        public System.Guid OrganizationUnityId { get; set; }
        public Domain.Persistence.Entities.OrganizationalUnity OrganizationUnity { get; set; }

        public System.Guid VacantId { get; set; }
        public Vacant Vacant { get; set; }

        public int Count { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SalaryStandardId))]
        public SalaryStandard SalaryStandard { get; set; }
        public System.Guid SalaryStandardId { get; set; }
    }
}
