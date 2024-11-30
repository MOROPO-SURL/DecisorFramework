using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionPlanConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProductionPlanDisplayModel>
    {
        private System.DateTime plannedFor;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.ElaborationDisplayModel elaboration;
        private EmployeeDisplayModel planner;
        private EmployeeDisplayModel responsible;
        private EmployeeDisplayModel decisor;
        private decimal amount;

        public ProductionPlanConfigurationPageModel(Interop.API.Common.Models.Display.ProductionPlanDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                PlannedFor = model.PlannedFor;
                Description = model.Description;
                Priority = model.Priority;
                Elaboration = model.Elaboration;
                Planner = model.Planner;
                Responsible = model.Responsible;
                Decisor = model.Decisor;
                Amount = model.Amount;
            }
            else
            {
                PlannedFor = System.DateTime.Now;
            }
        }

        public System.Guid Id { get; set; }

        public System.DateTime PlannerForMinDate { get; } = System.DateTime.Now;

        public System.DateTime PlannedFor { get => plannedFor; set => SetProperty(ref plannedFor, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.ElaborationDisplayModel Elaboration { get => elaboration; set => SetProperty(ref elaboration, value); }

        public EmployeeDisplayModel Planner { get => planner; set => SetProperty(ref planner, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public EmployeeDisplayModel Decisor { get => decisor; set => SetProperty(ref decisor, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public EmployeeDisplayModel[] AvailablePlanners { get; set; } = [];

        public EmployeeDisplayModel[] AvailableResponsibles { get; set; } = [];

        public EmployeeDisplayModel[] AvailableDecisors { get; set; } = [];
    }
}
