namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class SalaryStandardDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SalaryStandardDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> Build(Interop.API.Common.Models.Display.SalaryStandardDisplayModel model, System.Action<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.SalaryStandardDetailPage(model, delegationAction);
    }
}
