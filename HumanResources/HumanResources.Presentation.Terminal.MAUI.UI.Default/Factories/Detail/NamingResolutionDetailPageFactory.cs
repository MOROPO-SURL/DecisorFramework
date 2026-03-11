namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NamingResolutionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> Build(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NamingResolutionDetailPage(model, delegationAction);
    }
}