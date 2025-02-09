namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class WarehouseDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehouseDisplayModel, Pages.Detail.WarehouseDetailPage>
    {
        public Pages.Detail.WarehouseDetailPage Build(Interop.API.Common.Models.Display.WarehouseDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.WarehouseDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}