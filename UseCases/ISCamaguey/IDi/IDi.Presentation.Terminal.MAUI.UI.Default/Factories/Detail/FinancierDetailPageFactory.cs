namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class FinancierDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.FinancierDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.FinancierDisplayModel> Build(Interop.API.Common.Models.Display.FinancierDisplayModel model, System.Action<Interop.API.Common.Models.Display.FinancierDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.FinancierDetailPage(model, delegationAction);
        }
    }
}
