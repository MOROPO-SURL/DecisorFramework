namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalClientPropertyLeasingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientPropertyLeasingDetailPage(model, delegationAction);
        }
    }
}