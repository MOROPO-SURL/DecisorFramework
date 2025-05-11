namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class VehicleLeaseOfferDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel, Pages.Detail.VehicleLeaseOfferDetailPage>
    {
        public Pages.Detail.VehicleLeaseOfferDetailPage Build(Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.VehicleLeaseOfferDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}