namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class WorkPositionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Pages.Detail.WorkPositionDetailPage>
    {
        public Pages.Detail.WorkPositionDetailPage Build(Interop.API.Common.Models.Display.WorkPositionDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.WorkPositionDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
