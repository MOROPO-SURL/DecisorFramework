namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class StaffConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.StaffDisplayModel>
    {
        public static string StructureValidableProperty => nameof(Structure);
        public static string MainWorkforceStandardValidableProperty => nameof(MainWorkforce);
        public static string WorkingDayCountStandardValidableProperty => nameof(WorkingDayCount);

        private Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel structure;
        private Interop.API.Common.Models.Display.WorkforceDisplayModel mainWorkforce;
        private int workingDayCount = 24;

        public StaffConfigurationPageModel(Interop.API.Common.Models.Display.StaffDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                structure = model.Structure;
                mainWorkforce = model.MainWorkforce;
                workingDayCount = model.WorkingDayCount;
                AlternativeWorkforceBridges = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel>(model.AlternativeWorkforces);
            }
        }

        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public Interop.API.Common.Models.Display.WorkforceDisplayModel MainWorkforce { get => mainWorkforce; set => SetProperty(ref mainWorkforce, value); }

        public int WorkingDayCount { get => workingDayCount; set => SetProperty(ref workingDayCount, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel> AlternativeWorkforceBridges { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel[] AvailableStructures { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.WorkforceDisplayModel> AvailableWorkforces { get; set; } = [];
    }
}