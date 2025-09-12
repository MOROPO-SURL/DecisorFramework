namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VehicleLeaseOfferDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> Build(Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel model, System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VehicleLeaseOfferDetailPage(model, delegationAction);
        }
    }
}