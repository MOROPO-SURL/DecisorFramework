namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class VehicleDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleDisplayModel, Pages.Detail.VehicleDetailPage>
    {
        public Pages.Detail.VehicleDetailPage Build(Interop.API.Common.Models.Display.VehicleDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.VehicleDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}
