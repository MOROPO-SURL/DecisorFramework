namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ProformaDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProformaDisplayModel, Pages.Detail.ProformaDetailPage>
    {
        public Pages.Detail.ProformaDetailPage Build(Interop.API.Common.Models.Display.ProformaDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.ProformaDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.ProformaDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
