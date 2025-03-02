namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.WorkforceConfigurationVacantViewModel>
    {
        private int priority = 1;
        private bool namingResolutionRequired;
        private Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition;
        private Interop.API.Common.Models.Display.SalaryStandardDisplayModel salaryStandard;

        public VacantConfigurationPageModel(View.WorkforceConfigurationVacantViewModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                OrganizationUnity = model.OrganizationUnity;
                Priority = model.Priority;
                NamingResolutionRequired = model.NamingResolutionRequired;                
                WorkPosition = model.WorkPosition;
                SalaryStandard = model.SalaryStandard;
            }
        }

        public VacantConfigurationPageModel(View.WorkforceConfigurationOrganizationalUnityViewModel organizationUnity) : base(null)
        {
            OrganizationUnity = organizationUnity;
        }

        public System.Guid Id { get; set; }

        public View.WorkforceConfigurationOrganizationalUnityViewModel OrganizationUnity { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public bool NamingResolutionRequired { get => namingResolutionRequired; set => SetProperty(ref namingResolutionRequired, value); }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get => workPosition; set => SetProperty(ref workPosition, value); }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel SalaryStandard { get => salaryStandard; set => SetProperty(ref salaryStandard, value); }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel[] AvailableWorkPositions { get; set; }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel[] AvailableSalaryStandards { get; set; }
    }
}
