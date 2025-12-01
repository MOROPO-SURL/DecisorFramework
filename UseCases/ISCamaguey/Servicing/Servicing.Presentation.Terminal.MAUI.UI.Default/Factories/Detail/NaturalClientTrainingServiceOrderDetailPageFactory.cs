
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalClientTrainingServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientTrainingServiceOrderDetailPage(model, delegationAction);
        }
    }
}
