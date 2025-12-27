namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ProgramDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProgramDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProgramDisplayModel> Build(Interop.API.Common.Models.Display.ProgramDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProgramDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProgramDetailPage(model, delegationAction);
    }
}
