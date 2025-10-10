namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class AdmitionPropousalDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel> Build(Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel model, System.Action<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.AdmitionPropousalDetailPage(model, delegationAction);
        }
    }
}