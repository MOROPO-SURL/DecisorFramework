namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class ProyectionConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProyectionDisplayModel>
    {
        private string name;
        private string description;
        private int index = 1;

        public ProyectionConfigurationPageModel() : this(null) { }

        public ProyectionConfigurationPageModel(Interop.API.Common.Models.Display.ProyectionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Index = model.Index;
                Name = model.Name;
                Description = model.Description;
            }
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
