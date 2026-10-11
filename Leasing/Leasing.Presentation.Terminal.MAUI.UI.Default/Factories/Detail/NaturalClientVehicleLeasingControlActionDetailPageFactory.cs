namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientVehicleLeasingControlActionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientVehicleLeasingControlActionDetailPage(model, delegationAction);
    }
}