namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PurchaseRequestDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel> Build(Interop.API.Common.Models.Display.PurchaseRequestDisplayModel model, System.Action<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PurchaseRequestDetailPage(model, delegationAction);
        }
    }
}
