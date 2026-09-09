namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CallForProposalConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CallForProposalDisplayModel>
    {
        public static string TitleValidableProperty => nameof(Title);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string FinancierValidableProperty => nameof(Financier);
        public static string EndAtValidableProperty => nameof(EndAt);

        private string title;
        private string description;
        private System.DateTime startAt = System.DateTime.Today;
        private System.DateTime endAt = System.DateTime.Today.AddMonths(1);
        private Interop.API.Common.Models.Display.FinancierDisplayModel financier;

        public CallForProposalConfigurationPageModel(Interop.API.Common.Models.Display.CallForProposalDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            title = model.Title;
            description = model.Description;
            startAt = model.StartAt;
            endAt = model.EndAt;
            financier = model.Financier;
            KnowledgeAreas = [.. model.KnowledgeAreas];
            Documents = [.. model.Documents];
        }

        public System.Guid Id { get; set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

        public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }

        public Interop.API.Common.Models.Display.FinancierDisplayModel Financier { get => financier; set => SetProperty(ref financier, value); }

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel> KnowledgeAreas { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}
