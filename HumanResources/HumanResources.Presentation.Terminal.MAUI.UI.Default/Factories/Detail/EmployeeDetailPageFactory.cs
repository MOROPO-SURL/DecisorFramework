namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel, Pages.Detail.EmployeeDetailPage>
    {
        public Pages.Detail.EmployeeDetailPage Build(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model, System.Action<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.EmployeeDetailPage(model);
        }
    }
}