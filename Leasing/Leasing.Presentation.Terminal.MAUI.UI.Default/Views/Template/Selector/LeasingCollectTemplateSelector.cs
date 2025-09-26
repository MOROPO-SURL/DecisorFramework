namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Views.Template.Selector
{
    public class LeasingCollectTemplateSelector : Microsoft.Maui.Controls.DataTemplateSelector
    {
        public Microsoft.Maui.Controls.DataTemplate LegalClientPropertyLeasingCollectDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate NaturalClientPropertyLeasingCollectDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate LegalClientVehicleLeasingCollectDataTemplate { get; set; }

        public Microsoft.Maui.Controls.DataTemplate NaturalClientVehicleLeasingCollectDataTemplate { get; set; }

        protected override Microsoft.Maui.Controls.DataTemplate OnSelectTemplate(object item, Microsoft.Maui.Controls.BindableObject container)
        {
            var concreteItem = item as Models.View.LeasingCollectViewModel;

            if (concreteItem.InteropModel is Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel)
            {
                return LegalClientPropertyLeasingCollectDataTemplate;
            }
            else if (concreteItem.InteropModel is Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel)
            {
                return NaturalClientPropertyLeasingCollectDataTemplate;
            }
            else if (concreteItem.InteropModel is Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel)
            {
                return LegalClientVehicleLeasingCollectDataTemplate;
            }
            else if (concreteItem.InteropModel is Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel)
            {
                return NaturalClientVehicleLeasingCollectDataTemplate;
            }

            throw new System.InvalidOperationException();
        }
    }
}
