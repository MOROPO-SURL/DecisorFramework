namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class AwardKindDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AwardKindDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AwardKindDisplayModel> Build(Interop.API.Common.Models.Display.AwardKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.AwardKindDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AwardKindDetailPage(model, delegationAction);
    }
}