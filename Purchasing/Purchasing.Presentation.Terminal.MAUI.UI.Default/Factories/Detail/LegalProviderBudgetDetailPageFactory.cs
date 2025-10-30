namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalProviderBudgetDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel> Build(Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalProviderBudgetDetailPage(model, delegationAction);
        }
    }
}