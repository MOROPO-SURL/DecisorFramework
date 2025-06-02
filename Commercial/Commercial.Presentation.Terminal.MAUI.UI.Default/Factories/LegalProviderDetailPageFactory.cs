namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class LegalProviderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalProviderDisplayModel, Pages.Detail.LegalProviderDetailPage>
    {
        public Pages.Detail.LegalProviderDetailPage Build(Interop.API.Common.Models.Display.LegalProviderDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalProviderDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.LegalProviderDetailPage(model, delegationAction);
        }
    }
}
