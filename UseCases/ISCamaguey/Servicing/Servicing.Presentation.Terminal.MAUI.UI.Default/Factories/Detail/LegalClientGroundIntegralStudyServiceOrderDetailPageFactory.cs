
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientGroundIntegralStudyServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientGroundIntegralStudyServiceOrderDetailPage(model, delegationAction);
        }
    }
}
