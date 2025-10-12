namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class VacantDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Vacant, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Persistence.Enumerations.VacantOcupationMode OcupationMode { get; set; }

        public WorkPositionDisplayModel WorkPosition { get; set; }

        public System.Guid WorkforceOrganizationUnityId { get; set; }

        public SalaryStandardDisplayModel SalaryStandard { get; set; }

        public void Import(Persistence.Entities.Vacant entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            OcupationMode = entity.OcupationMode;
            WorkforceOrganizationUnityId = entity.WorkforceOrganizationalUnityId;

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
