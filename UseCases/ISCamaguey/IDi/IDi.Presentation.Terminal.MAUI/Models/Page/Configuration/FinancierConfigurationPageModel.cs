namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class FinancierConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.FinancierDisplayModel>
    {
        public static string ContactValidableProperty => nameof(Contact);

        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private int priority = 1;

        public FinancierConfigurationPageModel(Interop.API.Common.Models.Display.FinancierDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            contact = model.Contact;
            priority = model.Priority;
            ResearchAreas = [.. model.ResearchAreas];
            Documents = [.. model.Documents];
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> ResearchAreas { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}
