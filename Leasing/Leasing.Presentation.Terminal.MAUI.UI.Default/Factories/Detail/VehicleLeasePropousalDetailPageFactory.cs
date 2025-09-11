namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VehicleLeasePropousalDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, Pages.Detail.VehicleLeasePropousalDetailPage>
    {
        public Pages.Detail.VehicleLeasePropousalDetailPage Build(Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel model, System.Action<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VehicleLeasePropousalDetailPage(model, delegationAction);
        }
    }
}
