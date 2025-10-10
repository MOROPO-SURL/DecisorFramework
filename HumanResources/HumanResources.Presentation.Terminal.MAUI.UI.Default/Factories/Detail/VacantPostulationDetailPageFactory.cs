namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VacantPostulationDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VacantPostulationDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VacantPostulationDisplayModel> Build(Interop.API.Common.Models.Display.VacantPostulationDisplayModel model, System.Action<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VacantPostulationDetailPage(model, delegationAction);
        }
    }
}