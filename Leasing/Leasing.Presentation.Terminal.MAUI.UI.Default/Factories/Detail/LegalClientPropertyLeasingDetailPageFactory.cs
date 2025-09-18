namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalClientPropertyLeasingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalClientPropertyLeasingDetailPage(model, delegationAction);
        }
    }
}