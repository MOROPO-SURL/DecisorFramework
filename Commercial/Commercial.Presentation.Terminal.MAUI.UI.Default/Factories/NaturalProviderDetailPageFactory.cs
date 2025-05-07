namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class NaturalProviderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Pages.Detail.NaturalProviderDetailPage>
    {
        public Pages.Detail.NaturalProviderDetailPage Build(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.NaturalProviderDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
