namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class VehicleEngineKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel, Pages.Detail.VehicleEngineKindDetailPage>
    {
        public Pages.Detail.VehicleEngineKindDetailPage Build(Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.VehicleEngineKindDetailPage(model);
        }
    }
}
