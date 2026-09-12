namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class AssessmentDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.View.AssessmentDetailViewModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.View.AssessmentDetailViewModel> Build(Models.View.AssessmentDetailViewModel model, System.Action<Models.View.AssessmentDetailViewModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AssessmentDetailPage(model, delegationAction);
    }
}