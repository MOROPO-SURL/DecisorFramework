namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class BankAgencyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAgencyDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.BankAgencyDisplayModel> Build(Interop.API.Common.Models.Display.BankAgencyDisplayModel model, System.Action<Interop.API.Common.Models.Display.BankAgencyDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.BankAgencyDetailPage(model, delegationAction);
        }
    }
}
