using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ElaborationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ElaborationDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string ProductValidableProperty => nameof(Product);
        public static string ClassificationValidableProperty => nameof(Classification);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string StepsValidableProperty => nameof(Steps);
        public static string MinPerformanceCoefficientValidableProperty => nameof(MinPerformanceCoefficient);
        public static string MaxPerformanceCoefficientCoefficientValidableProperty => nameof(MaxPerformanceCoefficient);

        private string name;
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel classification;
        private string description;
        private int priority = 1;
        private decimal minPerformanceCoefficient;
        private decimal maxPerformanceCoefficient;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] availableClassifications;

        public ElaborationConfigurationPageModel(Interop.API.Common.Models.Display.ElaborationDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                name = model.Name;
                product = model.Product;
                classification = model.Classification;
                description = model.Description;
                priority = model.Priority;
                minPerformanceCoefficient = model.MinPerformanceCoefficient;
                maxPerformanceCoefficient = model.MaxPerformanceCoefficient;
                InputProductBridges = [.. model.InputProductBridges];
                OutputProductBridges = [.. model.OutputProductBridges];
                Steps = [.. model.Steps.OrderBy(_model => _model.Priority)];
                Documents = [.. model.Documents];
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get => classification; set => SetProperty(ref classification, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public decimal MinPerformanceCoefficient { get => minPerformanceCoefficient; set => SetProperty(ref minPerformanceCoefficient, value); }

        public decimal MaxPerformanceCoefficient { get => maxPerformanceCoefficient; set => SetProperty(ref maxPerformanceCoefficient, value); }

        public ObservableCollection<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel> InputProductBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel> OutputProductBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> Steps { get; set; } = [];

        public ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] AvailableClassifications { get => availableClassifications; set => SetProperty(ref availableClassifications, value); }
    }
}
