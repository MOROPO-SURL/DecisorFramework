namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PurchaseSpentDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel> Build(Interop.API.Common.Models.Display.PurchaseSpentDisplayModel model, System.Action<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PurchaseSpentDetailPage(model, delegationAction);
        }
    }
}