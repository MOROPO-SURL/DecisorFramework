namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PersonContactDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonContactDisplayModel, Pages.Detail.PersonContactDetailPage>
    {
        public Pages.Detail.PersonContactDetailPage Build(Interop.API.Common.Models.Display.PersonContactDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.PersonContactDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.PersonContactDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
