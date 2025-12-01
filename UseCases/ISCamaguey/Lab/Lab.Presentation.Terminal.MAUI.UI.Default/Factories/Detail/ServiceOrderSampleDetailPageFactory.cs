namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ServiceOrderSampleDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel> Build(Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel model, System.Action<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ServiceOrderSampleDetailPage(model, delegationAction);
    }
}