namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalProviderBudgetDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel> Build(Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalProviderBudgetDetailPage(model, delegationAction);
        }
    }
}
