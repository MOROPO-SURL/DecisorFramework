namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class OrganizationalUnityDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel> Build(Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.OrganizationalUnityDetailPage(model, delegationAction);
    }
}
