namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseZoneConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private string description;
        private int priority = 1;

        public PurchaseZoneConfigurationPageModel(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model) : base(model)
        {
            if (model == null) return;
            
            Id = model.Id;
            name = model.Name;
            description = model.Description;
            priority = model.Priority;
            SpentBridges = [.. model.SpentBridges];
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> SpentBridges { get; set; } = [];
    }
}
