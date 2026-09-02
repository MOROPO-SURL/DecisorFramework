namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ProductionSampleDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionSampleDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductionSampleDisplayModel> Build(Interop.API.Common.Models.Display.ProductionSampleDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductionSampleDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProductionSampleDetailPage(model, delegationAction);
    }
}