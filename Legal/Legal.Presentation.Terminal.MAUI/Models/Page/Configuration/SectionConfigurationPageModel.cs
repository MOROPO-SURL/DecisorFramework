using Microsoft.Maui.Graphics;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class SectionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.SectionDisplayModel>
    {
        private string name;
        private string title;
        private string content;
        private Interop.API.Common.Models.Display.SectionDisplayModel parent;
        private string descriptiont;
        private int priority = 1;

        public SectionConfigurationPageModel(Interop.API.Common.Models.Display.SectionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Title = model.Title;
                Content = model.Content;
                Parent = model.Parent;
                Description = model.Description;
                Priority = model.Priority;
            }
        }

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public string Description { get => descriptiont; set => SetProperty(ref descriptiont, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
        public Interop.API.Common.Models.Display.SectionDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

        public Interop.API.Common.Models.Display.SectionDisplayModel[] AvailableParents { get; set; }
    }
}
