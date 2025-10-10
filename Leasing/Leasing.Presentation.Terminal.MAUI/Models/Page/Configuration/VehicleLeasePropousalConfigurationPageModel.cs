using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeasePropousalConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VehicleLeasePropousalDisplayModel>
    {
        public static string VehicleValidableProperty => nameof(Vehicle);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string AuthorValidableProperty => nameof(Author);
        public static string AgreementValidableProperty => nameof(Agreement);

        private int priority = 1;
        private string description;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Domain.Interop.API.Common.Models.Display.VehicleDisplayModel vehicle;

        public VehicleLeasePropousalConfigurationPageModel(VehicleLeasePropousalDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            Priority = model.Priority;
            Description = model.Description;
            Author = model.Author;
            Agreement = model.Agreement;
            Vehicle = model.Vehicle;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get => vehicle; set => SetProperty(ref vehicle, value); }
    }
}
