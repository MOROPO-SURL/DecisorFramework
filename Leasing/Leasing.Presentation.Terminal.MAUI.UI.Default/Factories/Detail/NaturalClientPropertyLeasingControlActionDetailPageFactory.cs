namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientPropertyLeasingControlActionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientPropertyLeasingControlActionDetailPage(model, delegationAction);
    }
}