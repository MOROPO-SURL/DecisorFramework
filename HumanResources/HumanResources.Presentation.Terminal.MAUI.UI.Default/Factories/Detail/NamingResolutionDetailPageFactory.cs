namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NamingResolutionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Pages.Detail.NamingResolutionDetailPage>
    {
        public Pages.Detail.NamingResolutionDetailPage Build(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NamingResolutionDetailPage(model, delegationAction);
        }
    }
}