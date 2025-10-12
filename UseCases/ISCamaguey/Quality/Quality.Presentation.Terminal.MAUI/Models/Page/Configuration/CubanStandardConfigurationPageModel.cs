
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;
using System.Xml.Linq;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CubanStandardConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CubanStandardDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private int priority = 1;
        private string name;
        private string description;

        public CubanStandardConfigurationPageModel(Interop.API.Common.Models.Display.CubanStandardDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
        }

        public int Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
