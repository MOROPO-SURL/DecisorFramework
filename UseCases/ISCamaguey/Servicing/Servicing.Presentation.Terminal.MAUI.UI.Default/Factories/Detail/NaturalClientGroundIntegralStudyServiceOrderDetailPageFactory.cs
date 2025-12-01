
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalClientGroundIntegralStudyServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientGroundIntegralStudyServiceOrderDetailPage(model, delegationAction);
        }
    }
}
