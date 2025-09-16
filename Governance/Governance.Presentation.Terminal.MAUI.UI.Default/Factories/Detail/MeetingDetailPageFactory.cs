namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class MeetingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.MeetingDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.MeetingDisplayModel> Build(Interop.API.Common.Models.Display.MeetingDisplayModel model, System.Action<Interop.API.Common.Models.Display.MeetingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.MeetingDetailPage(model, delegationAction);
        }
    }
}