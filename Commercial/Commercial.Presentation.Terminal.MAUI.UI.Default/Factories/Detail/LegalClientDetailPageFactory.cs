namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientDisplayModel, Pages.Detail.LegalClientDetailPage>
    {
        public Pages.Detail.LegalClientDetailPage Build(Interop.API.Common.Models.Display.LegalClientDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientDetailPage(model, delegationAction);
        }
    }
}
