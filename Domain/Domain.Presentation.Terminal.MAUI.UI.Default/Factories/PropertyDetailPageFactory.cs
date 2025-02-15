namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PropertyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyDisplayModel, Pages.Detail.PropertyDetailPage>
    {
        public Pages.Detail.PropertyDetailPage Build(Interop.API.Common.Models.Display.PropertyDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.PropertyDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
