namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class SalaryStandardDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Pages.Detail.SalaryStandardDetailPage>
    {
        public Pages.Detail.SalaryStandardDetailPage Build(Interop.API.Common.Models.Display.SalaryStandardDisplayModel model, System.Action<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, int> delegationAction = null)
        {
            return new Pages.Detail.SalaryStandardDetailPage(model, delegationAction);
        }
    }
}
