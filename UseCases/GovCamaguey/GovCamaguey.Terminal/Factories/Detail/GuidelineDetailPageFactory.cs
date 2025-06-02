namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class GuidelineDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.GuidelineDisplayModel, UI.Pages.Detail.GuidelineDetailPage>
    {
        public UI.Pages.Detail.GuidelineDetailPage Build(Interop.API.Common.Models.Display.GuidelineDisplayModel model, System.Action<Interop.API.Common.Models.Display.GuidelineDisplayModel, int> delegationAction = null)
        {
            return new UI.Pages.Detail.GuidelineDetailPage(model, delegationAction);
        }
    }
}
