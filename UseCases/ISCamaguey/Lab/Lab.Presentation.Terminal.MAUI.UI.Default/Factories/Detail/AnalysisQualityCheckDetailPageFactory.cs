namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class AnalysisQualityCheckDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel> Build(Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel model, System.Action<Interop.API.Common.Models.Display.AnalysisQualityCheckDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AnalysisQualityCheckDetailPage(model, delegationAction);
    }
}