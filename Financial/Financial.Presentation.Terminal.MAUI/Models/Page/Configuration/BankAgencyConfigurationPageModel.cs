using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class BankAgencyConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<BankAgencyDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private string alias;
        private string about;
        private int priority = 1;
        private Microsoft.Maui.Controls.ImageSource imageSource;

        public BankAgencyConfigurationPageModel(BankAgencyDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Alias = model.Alias;
                About = model.About;
                Priority = model.Priority;

                if (model.Image != null)
                {
                    ImageId = model.Image.Id;
                    ImageSource = model.Image.ToImageSource();
                }
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? ImageId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Alias { get => alias; set => SetProperty(ref alias, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }
    }
}
