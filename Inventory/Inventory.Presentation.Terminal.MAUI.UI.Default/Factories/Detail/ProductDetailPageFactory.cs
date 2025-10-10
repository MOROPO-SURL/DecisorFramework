namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class ProductDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductDisplayModel> Build(Interop.API.Common.Models.Display.ProductDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.ProductDetailPage(model, delegationAction);
        }
    }
}
