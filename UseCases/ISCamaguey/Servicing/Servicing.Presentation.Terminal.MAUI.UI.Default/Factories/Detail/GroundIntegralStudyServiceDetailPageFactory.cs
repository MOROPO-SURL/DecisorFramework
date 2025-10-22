namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class GroundIntegralStudyServiceDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> Build(Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel model, System.Action<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.GroundIntegralStudyServiceDetailPage(model, delegationAction);
        }
    }
}