namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class CallForPropousalDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.CallForPropousalDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CallForPropousalDisplayModel> Build(Interop.API.Common.Models.Display.CallForPropousalDisplayModel model, System.Action<Interop.API.Common.Models.Display.CallForPropousalDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.CallForPropousalDetailPage(model, delegationAction);
        }
    }
}