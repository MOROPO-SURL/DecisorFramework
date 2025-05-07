namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ProductionOrderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionOrderDisplayModel, Pages.Detail.ProductionOrderDetailPage>
    {
        public Pages.Detail.ProductionOrderDetailPage Build(Interop.API.Common.Models.Display.ProductionOrderDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.ProductionOrderDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
