namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Views.Template.Selector;

public class ChangeNotificationViewSelector : Microsoft.Maui.Controls.DataTemplateSelector
{
    public Microsoft.Maui.Controls.DataTemplate NotReadedNotificationTemplate { get; set; }
    public Microsoft.Maui.Controls.DataTemplate ReadedNotificationTemplate { get; set; }

    protected override Microsoft.Maui.Controls.DataTemplate OnSelectTemplate(object item, Microsoft.Maui.Controls.BindableObject container)
    {
        if (item is Models.View.ChangeNotificationViewModel concreteItem)
        {
            if (concreteItem.Model.ReadedAt == null) return NotReadedNotificationTemplate;

            return ReadedNotificationTemplate;
        }

        throw new System.InvalidOperationException();
    }
}