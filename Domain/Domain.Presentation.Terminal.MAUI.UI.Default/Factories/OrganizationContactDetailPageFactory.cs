namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class OrganizationContactDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, Pages.Detail.OrganizationContactDetailPage>
    {
        public Pages.Detail.OrganizationContactDetailPage Build(Interop.API.Common.Models.Display.OrganizationContactDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.OrganizationContactDetailPage(model, delegationAction);
        }
    }
}
