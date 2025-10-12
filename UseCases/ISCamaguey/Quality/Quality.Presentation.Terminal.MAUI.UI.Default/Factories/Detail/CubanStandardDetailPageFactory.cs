
namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class CubanStandardDetailPageFactory: Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.CubanStandardDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CubanStandardDisplayModel> Build(Interop.API.Common.Models.Display.CubanStandardDisplayModel model, System.Action<Interop.API.Common.Models.Display.CubanStandardDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.CubanStandardDetailPage(model, delegationAction);
        }
    }
}
