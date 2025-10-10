namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.WorkforceConfigurationVacantViewModel>
    {
        private int priority = 1;
        private Persistence.Enumerations.VacantOcupationMode ocupationMode;
        private Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition;
        private Interop.API.Common.Models.Display.SalaryStandardDisplayModel salaryStandard;

        public VacantConfigurationPageModel(View.WorkforceConfigurationVacantViewModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                OrganizationUnity = model.OrganizationUnity;
                priority = model.Priority;
                ocupationMode = model.OcupationMode;                
                workPosition = model.WorkPosition;
                salaryStandard = model.SalaryStandard;
            }
        }

        public VacantConfigurationPageModel(View.WorkforceConfigurationOrganizationalUnityViewModel organizationUnity) : base(null)
        {
            OrganizationUnity = organizationUnity;
        }

        public System.Guid Id { get; set; }

        public View.WorkforceConfigurationOrganizationalUnityViewModel OrganizationUnity { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Persistence.Enumerations.VacantOcupationMode OcupationMode { get => ocupationMode; set => SetProperty(ref ocupationMode, value); }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get => workPosition; set => SetProperty(ref workPosition, value); }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel SalaryStandard { get => salaryStandard; set => SetProperty(ref salaryStandard, value); }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel[] AvailableWorkPositions { get; set; }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel[] AvailableSalaryStandards { get; set; }

        public Persistence.Enumerations.VacantOcupationMode[] AvailableVacantOcupationModes => [Persistence.Enumerations.VacantOcupationMode.Admision, Persistence.Enumerations.VacantOcupationMode.Naming, Persistence.Enumerations.VacantOcupationMode.Hybrid];
    }
}
