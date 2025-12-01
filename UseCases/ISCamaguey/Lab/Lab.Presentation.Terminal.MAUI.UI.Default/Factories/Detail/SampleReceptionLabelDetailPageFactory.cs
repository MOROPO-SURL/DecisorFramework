namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class SampleReceptionLabelDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel> Build(Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel model, System.Action<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.SampleReceptionLabelDetailPage(model, delegationAction);
    }
}