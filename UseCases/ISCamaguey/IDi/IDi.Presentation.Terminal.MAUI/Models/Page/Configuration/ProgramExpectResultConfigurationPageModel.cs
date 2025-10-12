namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProgramExpectResultConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel>
    {
        public static string TitleValidableProperty => nameof(Title);
        public static string IndexValidableProperty => nameof(Index);
        public static string DescriptionValidableProperty => nameof(Description);

        private int index;
        private string title;
        private string description;

        public ProgramExpectResultConfigurationPageModel(Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            index = model.Index;
            title = model.Title;
            description = model.Description;
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
