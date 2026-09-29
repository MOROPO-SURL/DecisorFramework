namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ScientificTechnicalResultDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel> Build(Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel model, System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ScientificTechnicalResultDetailPage(model, delegationAction);
    }
}