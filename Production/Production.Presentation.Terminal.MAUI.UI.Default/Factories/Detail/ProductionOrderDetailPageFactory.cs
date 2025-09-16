namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class ProductionOrderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> Build(Interop.API.Common.Models.Display.ProductionOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.ProductionOrderDetailPage(model, delegationAction);
        }
    }
}
