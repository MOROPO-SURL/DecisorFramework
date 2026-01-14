namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class StaffDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.StaffDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.StaffDisplayModel> Build(Interop.API.Common.Models.Display.StaffDisplayModel model, System.Action<Interop.API.Common.Models.Display.StaffDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.StaffDetailPage(model, delegationAction);
    }
}
