namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PaymentTermDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PaymentTermDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PaymentTermDisplayModel> Build(Interop.API.Common.Models.Display.PaymentTermDisplayModel model, System.Action<Interop.API.Common.Models.Display.PaymentTermDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PaymentTermDetailPage(model);
        }
    }
}
