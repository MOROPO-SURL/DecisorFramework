using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CertificationConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<CertificationDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private int priority = 1;
        private string name;
        private string description;
        private System.DateTime creationDateTime = System.DateTime.Now;

        public CertificationConfigurationPageModel(CertificationDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            name = model.Name;
            description = model.Description;
            creationDateTime = model.Created;
            CubanStandards = [.. model.CubanStandards];
            IsoStandards = [.. model.IsoStandards];
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.DateTime Created { get => creationDateTime; set => SetProperty(ref creationDateTime, value); }

        public System.Collections.ObjectModel.ObservableCollection<CubanStandardDisplayModel> CubanStandards { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<IsoStandardDisplayModel> IsoStandards { get; set; } = [];
    }
}
