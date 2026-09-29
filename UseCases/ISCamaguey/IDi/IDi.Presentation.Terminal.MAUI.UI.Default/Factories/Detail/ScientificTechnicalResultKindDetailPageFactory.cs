namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ScientificTechnicalResultKindDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel> Build(Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ScientificTechnicalResultKindDetailPage(model, delegationAction);
    }
}