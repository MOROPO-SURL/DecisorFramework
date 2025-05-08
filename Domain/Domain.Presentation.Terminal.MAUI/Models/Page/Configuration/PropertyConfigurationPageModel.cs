using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PropertyDisplayModel>
    {
        private int priority = 1;
        private Microsoft.Maui.Controls.ImageSource fatureImageSource;
        private string name;
        private PropertyKindDisplayModel kind;
        private StructureParentalDisplayModel structure;
        private PostalContactItemDisplayModel postalContact;
        private string reference;
        private decimal area;
        private string description;

        public PropertyConfigurationPageModel() : this(null) { }

        public PropertyConfigurationPageModel(PropertyDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Priority = model.Priority;
                Name = model.Name;
                Kind = model.Kind;
                Structure = model.Structure;
                PostalContact = model.PostalContact;
                Reference = model.Reference;
                Area = model.Area;
                Description = model.Description;

                if (model.FeatureImage != null)
                {
                    FeatureImageId = model.FeatureImage.Id;
                    FeatureImageSource = model.FeatureImage.ToImageSource();
                }

                ItemImageSources = new ObservableCollection<Microsoft.Maui.Controls.ImageSource>(model.Images.Select(_model => _model.ToImageSource()));
                ItemImageModels = model.Images.ToList();
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Microsoft.Maui.Controls.ImageSource FeatureImageSource { get => fatureImageSource; set => SetProperty(ref fatureImageSource, value); }

        public PropertyKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

        public StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public PostalContactItemDisplayModel PostalContact { get => postalContact; set => SetProperty(ref postalContact, value); }

        public string Reference { get => reference; set => SetProperty(ref reference, value); }

        public decimal Area { get => area; set => SetProperty(ref area, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public ObservableCollection<Microsoft.Maui.Controls.ImageSource> ItemImageSources { get; set; } = [];

        public System.Collections.Generic.List<ImageDisplayModel> ItemImageModels { get; set; }

        public PropertyKindDisplayModel[] AvailableKinds { get; set; }

        public StructureParentalDisplayModel[] AvailableStructures { get; set; }
    }
}
