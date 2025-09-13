namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class OrganizationDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationDisplayModel> Build(Interop.API.Common.Models.Display.OrganizationDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel, int?> delegationAction = null)
        {
            return new UI.Pages.Detail.OrganizationDetailPage(model, delegationAction);
        }
    }
}
