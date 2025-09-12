namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class ClauseDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ClauseDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ClauseDisplayModel> Build(Interop.API.Common.Models.Display.ClauseDisplayModel model, System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.ClauseDetailPage(model, delegationAction);
        }
    }
}
