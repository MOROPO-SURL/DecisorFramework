using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseZoneConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
    {
        private string name;
        private string description;
        private int priority = 1;

        public PurchaseZoneConfigurationPageModel() : this(null) { }

        public PurchaseZoneConfigurationPageModel(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;

                foreach (var item in model.SpentBridges) SpentBridges.Add(item);
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public ObservableCollection<PurchaseZoneSpentBridgeModel> SpentBridges { get; set; } = new ObservableCollection<PurchaseZoneSpentBridgeModel>();
    }
}
