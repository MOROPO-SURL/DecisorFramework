namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class VacantDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Vacant, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public bool NamingResolutionRequired { get; set; }

        public WorkPositionDisplayModel WorkPosition { get; set; }

        public System.Guid WorkforceId { get; set; }

        public System.Guid OrganizationUnityId { get; set; }

        public SalaryStandardDisplayModel SalaryStandard { get; set; }

        public void Import(Persistence.Entities.Vacant entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            NamingResolutionRequired = entity.NamingResolutionRequired;
            WorkforceId = entity.WorkforceId;
            OrganizationUnityId = entity.OrganizationUnityId;

            if (entity.WorkPosition != null)
            {
                WorkPosition = new WorkPositionDisplayModel();

                WorkPosition.Import(entity.WorkPosition);
            }

            if (entity.SalaryStandard != null)
            {
                SalaryStandard = new SalaryStandardDisplayModel();

                SalaryStandard.Import(entity.SalaryStandard);
            }
        }
    }
}
