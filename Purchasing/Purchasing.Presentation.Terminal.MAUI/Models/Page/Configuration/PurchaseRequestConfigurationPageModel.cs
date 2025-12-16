namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseRequestConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel>
    {
        public static string AuthorValidableProperty => nameof(Author);
        public static string ArgumentValidableProperty => nameof(Argument);
        public static string ExpectedProductAdquisitionsValidableProperty => nameof(ExpectedProductAdquisitions);

        private string argument;
        private int priority = 1;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;

        public PurchaseRequestConfigurationPageModel(Interop.API.Common.Models.Display.PurchaseRequestDisplayModel model = null) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            argument = model.Argument;
            priority = model.Priority;
            author = model.Author;
            ExpectedProductAdquisitions = [.. model.ExpectedProductAdquisitions];
        }

        public System.Guid Id { get; set; }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel> ExpectedProductAdquisitions { get; set; } = [];
    }
}
