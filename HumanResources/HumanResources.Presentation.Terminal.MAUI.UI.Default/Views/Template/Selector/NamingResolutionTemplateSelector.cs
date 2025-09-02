namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Template.Selector
{
    public class NamingResolutionTemplateSelector : Microsoft.Maui.Controls.DataTemplateSelector
    {
        public Microsoft.Maui.Controls.DataTemplate DirectNamingResolutionDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate CandidateNamingResolutionDataTemplate { get; set; }

        protected override Microsoft.Maui.Controls.DataTemplate OnSelectTemplate(object item, Microsoft.Maui.Controls.BindableObject container)
        {
            var concreteItem = item as Interop.API.Common.Models.Display.NamingResolutionDisplayModel;

            if (concreteItem.Contact != null) return DirectNamingResolutionDataTemplate;

            return CandidateNamingResolutionDataTemplate;
        }
    }
}
