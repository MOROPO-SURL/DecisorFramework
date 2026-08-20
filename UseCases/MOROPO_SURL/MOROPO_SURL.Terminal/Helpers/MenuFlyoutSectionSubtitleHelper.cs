namespace MOROPO.Tool.Decisor.Terminal.Helpers;

internal class MenuFlyoutSectionSubtitleHelper : Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IMenuFlyoutSectionSubtitleHelperFacade
{
    public bool MostPresentedAsSubtitle(Microsoft.Maui.Controls.ShellItem shellItem)
    {
        if (shellItem.Title.StartsWith("» ") && shellItem.Title.EndsWith(" «")) return true;

        return false;
    }
}
