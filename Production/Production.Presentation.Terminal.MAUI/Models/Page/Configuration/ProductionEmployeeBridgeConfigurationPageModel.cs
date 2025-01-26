using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionEmployeeBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel>
    {
        private HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel employee;
        private ElaborationStepDisplayModel step;
        private ProductionRoleDisplayModel role;

        public ProductionEmployeeBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Employee = model.Employee;
                Step = model.Step;
                Role = model.Role;
            }
        }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get => employee; set => SetProperty(ref employee, value); }

        public ElaborationStepDisplayModel Step { get => step; set => SetProperty(ref step, value); }

        public ProductionRoleDisplayModel Role { get => role; set => SetProperty(ref role, value); }

        public ElaborationStepDisplayModel[] AvailableSteps { get; set; } = [];

        public ObservableCollection<ProductionRoleDisplayModel> AvailableRoles { get; set; } = [];
    }
}
