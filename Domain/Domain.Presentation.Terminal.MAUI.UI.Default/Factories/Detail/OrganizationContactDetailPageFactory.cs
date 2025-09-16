namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class OrganizationContactDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OrganizationContactDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> Build(Interop.API.Common.Models.Display.OrganizationContactDisplayModel model, System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.OrganizationContactDetailPage(model, delegationAction);
        }
    }
}
