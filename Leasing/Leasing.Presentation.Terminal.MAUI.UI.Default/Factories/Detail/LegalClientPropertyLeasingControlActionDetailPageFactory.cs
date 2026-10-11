namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientPropertyLeasingControlActionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientPropertyLeasingControlActionDetailPage(model, delegationAction);
    }
}