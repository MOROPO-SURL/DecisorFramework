namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ClauseConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ClauseDisplayModel>
    {
        private string name;
        private string content;
        private int priority;

        public ClauseConfigurationPageModel(Interop.API.Common.Models.Display.ClauseDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Content = model.Content;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
