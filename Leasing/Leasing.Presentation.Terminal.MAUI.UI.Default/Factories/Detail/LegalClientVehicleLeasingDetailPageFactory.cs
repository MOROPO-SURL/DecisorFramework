namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientVehicleLeasingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel, Pages.Detail.LegalClientVehicleLeasingDetailPage>
    {
        public Pages.Detail.LegalClientVehicleLeasingDetailPage Build(Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientVehicleLeasingDetailPage(model, delegationAction);
        }
    }
}
