using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ElaborationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ElaborationDisplayModel>
    {
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel classification;
        private string description;
        private int priority = 1;
        private decimal referenceAmount;
        private decimal minPerformanceCoefficient;
        private decimal maxPerformanceCoefficient;

        public ElaborationConfigurationPageModel(Interop.API.Common.Models.Display.ElaborationDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Product = model.Product;
                Classification = model.Classification;
                Description = model.Description;
                Priority = model.Priority;
                ReferenceAmount = model.ReferenceAmount;
                MinPerformanceCoefficient = model.MinPerformanceCoefficient;
                MaxPerformanceCoefficient = model.MaxPerformanceCoefficient;

                foreach (var item in model.InputProducts) InputProducts.Add(item);

                foreach (var item in model.OutputProducts) OutputProducts.Add(item);

                foreach (var item in model.Steps) Steps.Add(item);
            }
        }

        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get => classification; set => SetProperty(ref classification, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public decimal ReferenceAmount { get => referenceAmount; set => SetProperty(ref referenceAmount, value); }

        public decimal MinPerformanceCoefficient { get => minPerformanceCoefficient; set => SetProperty(ref minPerformanceCoefficient, value); }

        public decimal MaxPerformanceCoefficient { get => maxPerformanceCoefficient; set => SetProperty(ref maxPerformanceCoefficient, value); }

        public ObservableCollection<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel> InputProducts { get; set; } = [];

        public ObservableCollection<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel> OutputProducts { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> Steps { get; set; } = [];

        public ObservableCollection<Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel> AvailableClassifications { get; set; } = [];
    }
}
