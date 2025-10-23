namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class InternalResearcherDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.InternalResearcherDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.InternalResearcherDisplayModel> Build(Interop.API.Common.Models.Display.InternalResearcherDisplayModel model, System.Action<Interop.API.Common.Models.Display.InternalResearcherDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.InternalResearcherDetailPage(model, delegationAction);
        }
    }
}
