namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PurchaseZoneDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Pages.Detail.PurchaseZoneDetailPage>
    {
        public Pages.Detail.PurchaseZoneDetailPage Build(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.PurchaseZoneDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
