namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class ExternalResearcherDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel> Build(Interop.API.Common.Models.Display.ExternalResearcherDisplayModel model, System.Action<Interop.API.Common.Models.Display.ExternalResearcherDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.ExternalResearcherDetailPage(model, delegationAction);
        }
    }
}
