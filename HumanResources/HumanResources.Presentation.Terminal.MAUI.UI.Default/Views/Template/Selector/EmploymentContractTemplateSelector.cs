namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Template.Selector
{
    public class EmploymentContractTemplateSelector : Microsoft.Maui.Controls.DataTemplateSelector
    {
        public Microsoft.Maui.Controls.DataTemplate DesignationContractDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate NamingContractDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate AdmitionContractDataTemplate { get; set; }

        protected override Microsoft.Maui.Controls.DataTemplate OnSelectTemplate(object item, Microsoft.Maui.Controls.BindableObject container)
        {
            if (item is Interop.API.Common.Models.Display.DesignationEmploymentContractDisplayModel) return DesignationContractDataTemplate;

            if (item is Interop.API.Common.Models.Display.NamingEmploymentContractDisplayModel) return NamingContractDataTemplate;
            
            if (item is Interop.API.Common.Models.Display.AdmitionEmploymentContractDisplayModel) return AdmitionContractDataTemplate;

            throw new System.InvalidOperationException();
        }
    }
}
