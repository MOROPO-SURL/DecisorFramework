namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PropertyLeasePropousalDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel> Build(Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel model, System.Action<Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PropertyLeasePropousalDetailPage(model, delegationAction);
        }
    }
}
