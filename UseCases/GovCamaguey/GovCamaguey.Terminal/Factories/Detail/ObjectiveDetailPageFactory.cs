namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class ObjectiveDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ObjectiveDisplayModel, UI.Pages.Detail.ObjectiveDetailPage>
    {
        public UI.Pages.Detail.ObjectiveDetailPage Build(Interop.API.Common.Models.Display.ObjectiveDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.ObjectiveDisplayModel> completationFeedbackAction = null)
        {
            return new UI.Pages.Detail.ObjectiveDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
