namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientVehicleLeasingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientVehicleLeasingDetailPage(model, delegationAction);
        }
    }
}
