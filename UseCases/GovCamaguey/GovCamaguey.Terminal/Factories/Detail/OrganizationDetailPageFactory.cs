namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class OrganizationDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationDisplayModel, UI.Pages.Detail.OrganizationDetailPage>
    {
        public UI.Pages.Detail.OrganizationDetailPage Build(Interop.API.Common.Models.Display.OrganizationDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel, int> delegationAction = null)
        {
            return new UI.Pages.Detail.OrganizationDetailPage(model, delegationAction);
        }
    }
}
