namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class WorkforceConfigurationVacantViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private int priority;
        private bool namingResolutionRequired;
        private Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition;
        private Interop.API.Common.Models.Display.SalaryStandardDisplayModel salaryStandard;

        public System.Guid Id { get; set; }

        public WorkforceConfigurationOrganizationalUnityViewModel OrganizationUnity { get; set; }

        public int Priority { get => priority; set => priority = value; }

        public bool NamingResolutionRequired { get => namingResolutionRequired; set => namingResolutionRequired = value; }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get => workPosition; set => SetProperty(ref workPosition, value); }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel SalaryStandard { get => salaryStandard; set => SetProperty(ref salaryStandard, value); }
    }
}
