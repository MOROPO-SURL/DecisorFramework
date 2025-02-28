namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.View
{
    public class ProformaSectionClauseBridgeViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ClauseDisplayModel> clauses = [];

        public Interop.API.Common.Models.Display.SectionDisplayModel Section { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ClauseDisplayModel> Clauses { get => clauses; set => SetProperty(ref clauses, value); }
    }
}
