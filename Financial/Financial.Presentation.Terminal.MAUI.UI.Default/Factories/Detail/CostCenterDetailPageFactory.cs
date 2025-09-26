namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class CostCenterDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.CostCenterDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CostCenterDisplayModel> Build(Interop.API.Common.Models.Display.CostCenterDisplayModel model, System.Action<Interop.API.Common.Models.Display.CostCenterDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.CostCenterDetailPage(model, delegationAction);
        }
    }
}