namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class SampleAnalysisServiceDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> Build(Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel model, System.Action<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.SampleAnalysisServiceDetailPage(model, delegationAction);
        }
    }
}