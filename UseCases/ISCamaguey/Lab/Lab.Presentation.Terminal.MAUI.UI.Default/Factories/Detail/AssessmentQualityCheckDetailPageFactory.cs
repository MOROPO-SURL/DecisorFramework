namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class AssessmentQualityCheckDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel> Build(Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel model, System.Action<Interop.API.Common.Models.Display.AssessmentQualityCheckDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AssessmentQualityCheckDetailPage(model, delegationAction);
    }
}