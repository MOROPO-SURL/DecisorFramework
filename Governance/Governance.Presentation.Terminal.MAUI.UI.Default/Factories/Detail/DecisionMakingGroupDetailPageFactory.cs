namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class DecisionMakingGroupDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> Build(Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel model, System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.DecisionMakingGroupDetailPage(model, delegationAction);
        }
    }
}
