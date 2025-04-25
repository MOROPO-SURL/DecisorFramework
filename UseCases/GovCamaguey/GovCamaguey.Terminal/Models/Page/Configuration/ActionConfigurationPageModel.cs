using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class ActionConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Input.ActionInputModel>
    {
        private string name;
        private string description;
        private int index = 1;

        public ActionConfigurationPageModel() : this(null) { }

        public ActionConfigurationPageModel(Interop.API.Common.Models.Input.ActionInputModel model, Interop.API.Common.Models.Display.IndicatorDisplayModel[] indicators = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Index = model.Index;
                Name = model.Name;
                Description = model.Description;

                if (indicators != null)
                {
                    Indicators = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.IndicatorDisplayModel>(indicators.OrderBy(_model => _model.Priority));
                }
            }
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.IndicatorDisplayModel> Indicators { get; set; } = [];
    }
}
