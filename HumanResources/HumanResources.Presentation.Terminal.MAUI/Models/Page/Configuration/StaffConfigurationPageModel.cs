namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class StaffConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.StaffDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel structure;
        private Interop.API.Common.Models.Display.WorkforceDisplayModel mainWorkforce;

        public StaffConfigurationPageModel(Interop.API.Common.Models.Display.StaffDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Structure = model.Structure;
                MainWorkforce = model.MainWorkforce;
                AlternativeWorkforceBridges = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel>(model.AlternativeWorkforces);
            }
        }

        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public Interop.API.Common.Models.Display.WorkforceDisplayModel MainWorkforce { get => mainWorkforce; set => SetProperty(ref mainWorkforce, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel> AlternativeWorkforceBridges { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel[] AvailableStructures { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.WorkforceDisplayModel> AvailableWorkforces { get; set; } = [];
    }
}