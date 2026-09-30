namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ScientificTechnicalResultIntroductionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel> Build(Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel model, System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ScientificTechnicalResultIntroductionDetailPage(model, delegationAction);
    }
}