namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ClauseDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ClauseDisplayModel, Pages.Detail.ClauseDetailPage>
    {
        public Pages.Detail.ClauseDetailPage Build(Interop.API.Common.Models.Display.ClauseDisplayModel model, System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.ClauseDetailPage(model, delegationAction);
        }
    }
}
