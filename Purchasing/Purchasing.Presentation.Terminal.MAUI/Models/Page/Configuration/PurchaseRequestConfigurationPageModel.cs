using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseRequestConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchaseRequestDisplayModel>
    {
        public static string AuthorValidableProperty => nameof(Author);
        public static string ArgumentValidableProperty => nameof(Argument);
        public static string ProductBridgesValidableProperty => nameof(ProductBridges);

        private string argument;
        private int priority = 1;
        private EmployeeDisplayModel author;

        public PurchaseRequestConfigurationPageModel(PurchaseRequestDisplayModel model = null) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            argument = model.Argument;
            priority = model.Priority;
            author = model.Author;
            ProductBridges = [.. model.ProductBridges];
        }

        public System.Guid Id { get; set; }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public System.Collections.ObjectModel.ObservableCollection<PurchaseCommonProductBridgeModel> ProductBridges { get; set; } = [];
    }
}
