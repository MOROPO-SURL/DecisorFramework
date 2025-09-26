namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalClientVehicleLeasingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientVehicleLeasingDetailPage(model, delegationAction);
        }
    }
}
