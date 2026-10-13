namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientVehicleLeasingControlActionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientVehicleLeasingControlActionDetailPage(model, delegationAction);
    }
}