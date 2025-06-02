namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class NaturalClientDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientDisplayModel, Pages.Detail.NaturalClientDetailPage>
    {
        public Pages.Detail.NaturalClientDetailPage Build(Interop.API.Common.Models.Display.NaturalClientDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientDetailPage(model, delegationAction);
        }
    }
}
