namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class RecomendationReportDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.RecomendationReportDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.RecomendationReportDisplayModel> Build(Interop.API.Common.Models.Display.RecomendationReportDisplayModel model, System.Action<Interop.API.Common.Models.Display.RecomendationReportDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.RecomendationReportDetailPage(model, delegationAction);
    }
}