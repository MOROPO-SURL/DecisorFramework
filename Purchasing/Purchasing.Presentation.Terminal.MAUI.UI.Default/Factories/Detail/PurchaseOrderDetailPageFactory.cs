namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PurchaseOrderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel> Build(Interop.API.Common.Models.Display.PurchaseOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PurchaseOrderDetailPage(model, delegationAction);
        }
    }
}