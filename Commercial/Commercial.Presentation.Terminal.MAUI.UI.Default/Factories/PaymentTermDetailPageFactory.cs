namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class PaymentTermDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PaymentTermDisplayModel, Pages.Detail.PaymentTermDetailPage>
    {
        public Pages.Detail.PaymentTermDetailPage Build(Interop.API.Common.Models.Display.PaymentTermDisplayModel model, System.Action<Interop.API.Common.Models.Display.PaymentTermDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.PaymentTermDetailPage(model);
        }
    }
}
