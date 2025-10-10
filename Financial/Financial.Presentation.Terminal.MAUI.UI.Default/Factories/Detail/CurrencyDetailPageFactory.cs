namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class CurrencyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.CurrencyDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CurrencyDisplayModel> Build(Interop.API.Common.Models.Display.CurrencyDisplayModel model, System.Action<Interop.API.Common.Models.Display.CurrencyDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.CurrencyDetailPage(model, delegationAction);
        }
    }
}