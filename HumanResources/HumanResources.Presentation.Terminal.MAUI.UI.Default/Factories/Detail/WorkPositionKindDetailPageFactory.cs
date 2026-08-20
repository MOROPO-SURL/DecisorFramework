namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class WorkPositionKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionKindDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkPositionKindDisplayModel> Build(Interop.API.Common.Models.Display.WorkPositionKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.WorkPositionKindDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.WorkPositionKindDetailPage(model);
    }
}
