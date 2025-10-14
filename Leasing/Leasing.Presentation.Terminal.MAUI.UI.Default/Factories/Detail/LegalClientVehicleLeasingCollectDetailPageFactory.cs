namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientVehicleLeasingCollectDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientVehicleLeasingCollectDetailPage(model, delegationAction);
        }
    }
}