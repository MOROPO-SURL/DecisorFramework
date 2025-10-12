
namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class IsoStandardDetailPageFactory: Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.IsoStandardDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.IsoStandardDisplayModel> Build(Interop.API.Common.Models.Display.IsoStandardDisplayModel model, System.Action<Interop.API.Common.Models.Display.IsoStandardDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.IsoStandardDetailPage(model, delegationAction);
        }
    }
}
