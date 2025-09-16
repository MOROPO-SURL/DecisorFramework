namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VehicleEngineKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel> Build(Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.VehicleEngineKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VehicleEngineKindDetailPage(model);
        }
    }
}
