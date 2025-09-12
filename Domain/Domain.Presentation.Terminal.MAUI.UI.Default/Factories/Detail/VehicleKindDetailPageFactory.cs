namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VehicleKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleKindDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleKindDisplayModel> Build(Interop.API.Common.Models.Display.VehicleKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.VehicleKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VehicleKindDetailPage(model);
        }
    }
}
