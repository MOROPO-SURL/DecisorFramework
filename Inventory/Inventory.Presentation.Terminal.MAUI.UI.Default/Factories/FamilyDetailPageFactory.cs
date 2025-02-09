namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class FamilyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.FamilyDisplayModel, Pages.Detail.FamilyDetailPage>
    {
        public Pages.Detail.FamilyDetailPage Build(Interop.API.Common.Models.Display.FamilyDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.FamilyDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}