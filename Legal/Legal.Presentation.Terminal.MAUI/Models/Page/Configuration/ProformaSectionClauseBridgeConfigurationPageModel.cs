namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProformaSectionClauseBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<View.SectionClauseBridgeViewModel>
    {
        private Interop.API.Common.Models.Display.SectionDisplayModel section;
        private Interop.API.Common.Models.Display.ClauseDisplayModel clause;

        public ProformaSectionClauseBridgeConfigurationPageModel(View.SectionClauseBridgeViewModel model) : base(model)
        {
            if (model != null)
            {
                Section = model.Section;
                Clause = model.Clause;
            }
        }

        public Interop.API.Common.Models.Display.SectionDisplayModel Section { get => section; set => SetProperty(ref section, value); }

        public Interop.API.Common.Models.Display.ClauseDisplayModel Clause { get => clause; set => SetProperty(ref clause, value); }

        public Interop.API.Common.Models.Display.SectionDisplayModel[] AvailableSections { get; set; }
    }
}
