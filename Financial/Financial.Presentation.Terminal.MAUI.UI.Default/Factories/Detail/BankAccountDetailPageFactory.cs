namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class BankAccountDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.BankAccountDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.BankAccountDisplayModel> Build(Interop.API.Common.Models.Display.BankAccountDisplayModel model, System.Action<Interop.API.Common.Models.Display.BankAccountDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.BankAccountDetailPage(model, delegationAction);
        }
    }
}
