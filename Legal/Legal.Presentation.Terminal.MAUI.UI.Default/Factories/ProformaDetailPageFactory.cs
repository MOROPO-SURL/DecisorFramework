namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class ProformaDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProformaDisplayModel, Pages.Detail.ProformaDetailPage>
    {
        public Pages.Detail.ProformaDetailPage Build(Interop.API.Common.Models.Display.ProformaDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProformaDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.ProformaDetailPage(model, delegationAction);
        }
    }
}
