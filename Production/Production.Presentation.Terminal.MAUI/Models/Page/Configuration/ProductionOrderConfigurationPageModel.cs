namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionOrderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>
    {
        public static string ElaborationValidableProperty => nameof(Elaboration);
        public static string AgreementValidableProperty => nameof(Agreement);
        public static string ResponsibleValidableProperty => nameof(Responsible);
        public static string AmountValidableProperty => nameof(Amount);

        private System.DateTime requestedFor;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.ElaborationDisplayModel elaboration;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel responsible;
        private decimal amount;

        public ProductionOrderConfigurationPageModel(Interop.API.Common.Models.Display.ProductionOrderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                requestedFor = model.RequestedFor;
                description = model.Description;
                priority = model.Priority;
                elaboration = model.Elaboration;
                agreement = model.Agreement;
                responsible = model.Responsible;
                amount = model.Amount;
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

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }
    }
}
