namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VacantPostulationDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, Pages.Detail.VacantPostulationDetailPage>
    {
        public Pages.Detail.VacantPostulationDetailPage Build(Interop.API.Common.Models.Display.VacantPostulationDisplayModel model, System.Action<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VacantPostulationDetailPage(model, delegationAction);
        }
    }
}