namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ProductionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProductionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductionDisplayModel> Build(Interop.API.Common.Models.Display.ProductionDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProductionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProductionDetailPage(model, delegationAction);
    }
}