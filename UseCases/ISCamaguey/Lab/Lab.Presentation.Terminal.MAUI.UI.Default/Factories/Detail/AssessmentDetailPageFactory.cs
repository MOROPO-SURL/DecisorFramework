namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class AssessmentDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AssessmentDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AssessmentDisplayModel> Build(Interop.API.Common.Models.Display.AssessmentDisplayModel model, System.Action<Interop.API.Common.Models.Display.AssessmentDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AssessmentDetailPage(model, delegationAction);
    }
}