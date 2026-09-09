namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View;

public class ChangeNotificationViewModel
{
    public string Title { get; set; }

    public string FeatureIconGlyph { get; set; }

    public Interop.API.Common.Models.Display.ChangeNotificationDisplayModel Model { get; set; }
}
