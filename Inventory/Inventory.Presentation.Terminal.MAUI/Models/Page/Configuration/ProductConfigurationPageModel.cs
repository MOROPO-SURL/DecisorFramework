using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProductDisplayModel>
    {
        private string name;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.UnitMeasurementDisplayModel defaultUnitMeasurement;
        private Interop.API.Common.Models.Display.FamilyDisplayModel category;
        private Microsoft.Maui.Controls.ImageSource featureImageSource;

        public ProductConfigurationPageModel() : this(null) { }

        public ProductConfigurationPageModel(Interop.API.Common.Models.Display.ProductDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
                DefaultUnitMeasurement = model.DefaultUnitMeasurement;
                Category = model.Category;
                Classifications = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ClassificationDisplayModel>(model.Classifications);

                if (model.FeatureImage != null)
                {
                    FeatureImageId = model.FeatureImage.Id;
                    FeatureImageSource = model.FeatureImage.ToImageSource();
                }
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel DefaultUnitMeasurement { get => defaultUnitMeasurement; set => SetProperty(ref defaultUnitMeasurement, value); }

        public Interop.API.Common.Models.Display.FamilyDisplayModel Category { get => category; set => SetProperty(ref category, value); }

        public Microsoft.Maui.Controls.ImageSource FeatureImageSource { get => featureImageSource; set => SetProperty(ref featureImageSource, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ClassificationDisplayModel> Classifications { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ClassificationDisplayModel>();

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.WarehousingDecreaseModel> WarehousingDecreases { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.WarehousingDecreaseModel>();

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }

        public Interop.API.Common.Models.Display.FamilyDisplayModel[] AvailableCategories { get; set; }
    }
}
