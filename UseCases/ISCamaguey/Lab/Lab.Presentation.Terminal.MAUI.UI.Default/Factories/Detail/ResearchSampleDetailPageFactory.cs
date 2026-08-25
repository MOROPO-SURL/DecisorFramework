namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ResearchSampleDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ResearchSampleDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ResearchSampleDisplayModel> Build(Interop.API.Common.Models.Display.ResearchSampleDisplayModel model, System.Action<Interop.API.Common.Models.Display.ResearchSampleDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ResearchSampleDetailPage(model, delegationAction);
    }
}
