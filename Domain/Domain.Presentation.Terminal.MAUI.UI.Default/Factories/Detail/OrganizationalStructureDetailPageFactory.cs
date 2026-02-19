namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class OrganizationalStructureDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel> Build(Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationalStructureDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.OrganizationalStructureDetailPage(model, delegationAction);
    }
}