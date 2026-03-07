namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class WorkforceConfigurationVacantViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private int priority;
        private Persistence.Enumerations.VacantOcupationMode vacantOcupationMode;
        private Interop.API.Common.Models.Display.WorkPositionDisplayModel workPosition;
        private Interop.API.Common.Models.Display.SalaryStandardDisplayModel salaryStandard;

        public System.Guid Id { get; set; }

        public Contract.AbstractWorkforceConfigurationOrganizationalStructuringUnitViewModel Context { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Persistence.Enumerations.VacantOcupationMode OcupationMode { get => vacantOcupationMode; set => SetProperty(ref vacantOcupationMode, value); }

        public Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get => workPosition; set => SetProperty(ref workPosition, value); }

        public Interop.API.Common.Models.Display.SalaryStandardDisplayModel SalaryStandard { get => salaryStandard; set => SetProperty(ref salaryStandard, value); }
    }
}
