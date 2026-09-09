namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class AnalysisDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AnalysisDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AnalysisDisplayModel> Build(Interop.API.Common.Models.Display.AnalysisDisplayModel model, System.Action<Interop.API.Common.Models.Display.AnalysisDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AnalysisDetailPage(model, delegationAction);
    }
}