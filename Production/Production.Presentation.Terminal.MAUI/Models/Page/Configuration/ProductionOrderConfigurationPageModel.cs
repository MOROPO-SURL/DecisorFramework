using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionOrderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>
    {
        private System.DateTime requestedFor;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.ElaborationDisplayModel elaboration;
        private EmployeeDisplayModel author;
        private EmployeeDisplayModel responsible;
        private EmployeeDisplayModel decisor;
        private decimal amount;

        public ProductionOrderConfigurationPageModel() : this(null) { }

        public ProductionOrderConfigurationPageModel(Interop.API.Common.Models.Display.ProductionOrderDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                RequestedFor = model.RequestedFor;
                Description = model.Description;
                Priority = model.Priority;
                Elaboration = model.Elaboration;
                Author = model.Author;
                Responsible = model.Responsible;
                Decisor = model.Decisor;
                Amount = model.Amount;
            }
            else
            {
                RequestedFor = System.DateTime.Now;
            }
        }

        public System.Guid Id { get; set; }

        public System.DateTime RequestedForMinDate { get; } = System.DateTime.Now;

        public System.DateTime RequestedFor { get => requestedFor; set => SetProperty(ref requestedFor, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.ElaborationDisplayModel Elaboration { get => elaboration; set => SetProperty(ref elaboration, value); }

        public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public EmployeeDisplayModel Decisor { get => decisor; set => SetProperty(ref decisor, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public EmployeeDisplayModel[] AvailableAuthors { get; set; } = [];

        public EmployeeDisplayModel[] AvailableResponsibles { get; set; } = [];

        public EmployeeDisplayModel[] AvailableDecisors { get; set; } = [];
    }
}
