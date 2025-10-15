using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class OcupationsManageVacantViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private OcupationDisplayModel ocupation;

        public System.Guid Id { get; set; }

        public System.Guid VacantId { get; set; }

        public Persistence.Enumerations.VacantOcupationMode VacantOcupationMode { get; set; }

        public WorkPositionDisplayModel WorkPosition { get; set; }

        public SalaryStandardDisplayModel SalaryStandard { get; set; }

        public OcupationDisplayModel Ocupation { get => ocupation; set => SetProperty(ref ocupation, value); }
    }
}
