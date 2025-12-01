
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientTrainingServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientTrainingServiceOrderDetailPage(model, delegationAction);
        }
    }
}
