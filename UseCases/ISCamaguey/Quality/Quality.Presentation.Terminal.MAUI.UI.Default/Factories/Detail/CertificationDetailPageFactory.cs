
namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class CertificationDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.CertificationDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CertificationDisplayModel> Build(Interop.API.Common.Models.Display.CertificationDisplayModel model, System.Action<Interop.API.Common.Models.Display.CertificationDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.CertificationDetailPage(model, delegationAction);
        }
    }
}
