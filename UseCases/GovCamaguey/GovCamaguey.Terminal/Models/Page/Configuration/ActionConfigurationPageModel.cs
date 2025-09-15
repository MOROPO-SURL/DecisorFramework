using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class ActionConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Input.ActionInputModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string IndexValidableProperty => nameof(Index);
        public static string ResponsabilityOrganizationsValidableProperty => nameof(ResponsabilityOrganizations);

        private string name;
        private string description;
        private int index = 1;

        public ActionConfigurationPageModel() : this(null) { }

        public ActionConfigurationPageModel(Interop.API.Common.Models.Input.ActionInputModel model, IndicatorDisplayModel[] indicators = null, ActionMonthlyClosureDisplayModel[] monthlyClosures = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Index = model.Index;
                Name = model.Name;
                Description = model.Description;
                ResponsabilityOrganizations = new ObservableCollection<OrganizationDisplayModel>(model.ResponsabilityOrganizations);
                ParticipationOrganizations = new ObservableCollection<OrganizationDisplayModel>(model.ParticipationOrganizations);

                if (indicators != null)
                {
                    Indicators = new ObservableCollection<IndicatorDisplayModel>(indicators.OrderBy(_model => _model.Priority));
                }
                
                if (monthlyClosures != null)
                {
                    MonthlyClosures = new ObservableCollection<ActionMonthlyClosureDisplayModel>(monthlyClosures.OrderBy(_model => _model.At));
                }
            }
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public ObservableCollection<OrganizationDisplayModel> ResponsabilityOrganizations { get; set; } = [];

        public ObservableCollection<OrganizationDisplayModel> ParticipationOrganizations { get; set; } = [];

        public ObservableCollection<IndicatorDisplayModel> Indicators { get; set; } = [];

        public ObservableCollection<ActionMonthlyClosureDisplayModel> MonthlyClosures { get; set; } = [];
    }
}
