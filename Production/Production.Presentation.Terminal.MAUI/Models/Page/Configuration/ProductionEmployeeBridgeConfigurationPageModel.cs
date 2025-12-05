using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionEmployeeBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel>
    {
        private Interop.API.Common.Models.Display.ElaborationStepDisplayModel step;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel employee;
        private HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel role;

        public ProductionEmployeeBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Employee = model.Employee;
                Step = model.Step;
                WorkPosition = model.WorkPosition;
            }
        }

        public Interop.API.Common.Models.Display.ElaborationStepDisplayModel Step { get => step; set => SetProperty(ref step, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get => employee; set => SetProperty(ref employee, value); }

        public HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel WorkPosition { get => role; set => SetProperty(ref role, value); }

        public Interop.API.Common.Models.Display.ElaborationStepDisplayModel[] AvailableSteps { get; set; } = [];

        public ObservableCollection<HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel> AvailableWorkPositions { get; set; } = [];
    }
}
