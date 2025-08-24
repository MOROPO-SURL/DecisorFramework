namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class OcupationCandidateDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, Pages.Detail.OcupationCandidateDetailPage>
    {
        public Pages.Detail.OcupationCandidateDetailPage Build(Interop.API.Common.Models.Display.OcupationCandidateDisplayModel model, System.Action<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.OcupationCandidateDetailPage(model, delegationAction);
        }
    }
}