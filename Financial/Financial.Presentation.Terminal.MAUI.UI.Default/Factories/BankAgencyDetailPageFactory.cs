namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class BankAgencyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAgencyDisplayModel, Pages.Detail.BankAgencyDetailPage>
    {
        public Pages.Detail.BankAgencyDetailPage Build(Interop.API.Common.Models.Display.BankAgencyDisplayModel model, System.Action<Interop.API.Common.Models.Display.BankAgencyDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.BankAgencyDetailPage(model, delegationAction);
        }
    }
}
