namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class WarehouseDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WarehouseDisplayModel, Pages.Detail.WarehouseDetailPage>
    {
        public Pages.Detail.WarehouseDetailPage Build(Interop.API.Common.Models.Display.WarehouseDisplayModel model, System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.WarehouseDetailPage(model, delegationAction);
        }
    }
}