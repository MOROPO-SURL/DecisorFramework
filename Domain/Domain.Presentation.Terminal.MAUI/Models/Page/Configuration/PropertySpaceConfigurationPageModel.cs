using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertySpaceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.PropertySpaceViewModel>
    {
        private string name;
        private string description;
        private Microsoft.Maui.Controls.ImageSource fatureImageSource;
        private decimal area;

        public PropertySpaceConfigurationPageModel(View.PropertySpaceViewModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Area = model.Area;

                if (model.InputFeatureImage != null)
                {
                    FeatureImageSource = model.InputFeatureImage.ToImageSource();
                }
                else if (model.CurrentFeatureImage != null)
                {
                    FeatureImageId = model.CurrentFeatureImage.Id;
                    FeatureImageSource = model.CurrentFeatureImage.ToImageSource();
                }
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Microsoft.Maui.Controls.ImageSource FeatureImageSource { get => fatureImageSource; set => SetProperty(ref fatureImageSource, value); }

        public decimal Area { get => area; set => SetProperty(ref area, value); }
    }
}
