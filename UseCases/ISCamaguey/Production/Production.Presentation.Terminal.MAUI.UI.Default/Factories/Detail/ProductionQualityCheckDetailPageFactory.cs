namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

internal sealed class ProductionQualityCheckDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel> Build(Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductionQualityCheckDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProductionQualityCheckDetailPage(model, delegationAction);
    }
}