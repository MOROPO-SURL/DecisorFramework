namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PurchaseZoneDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> Build(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel model, System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PurchaseZoneDetailPage(model, delegationAction);
        }
    }
}
