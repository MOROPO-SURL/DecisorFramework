namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class BankBranchDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.BankBranchDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.BankBranchDisplayModel> Build(Interop.API.Common.Models.Display.BankBranchDisplayModel model, System.Action<Interop.API.Common.Models.Display.BankBranchDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.BankBranchDetailPage(model, delegationAction);
        }
    }
}