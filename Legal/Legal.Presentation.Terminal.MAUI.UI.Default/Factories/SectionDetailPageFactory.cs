namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class SectionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SectionDisplayModel, Pages.Detail.SectionDetailPage>
    {
        public Pages.Detail.SectionDetailPage Build(Interop.API.Common.Models.Display.SectionDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.SectionDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.SectionDetailPage(model, delegationAction, completationFeedbackAction);
        }
    }
}