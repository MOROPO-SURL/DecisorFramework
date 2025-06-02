namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ProductDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductDisplayModel, Pages.Detail.ProductDetailPage>
    {
        public Pages.Detail.ProductDetailPage Build(Interop.API.Common.Models.Display.ProductDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.ProductDetailPage(model, delegationAction);
        }
    }
}
