namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class ProformaDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProformaDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProformaDisplayModel> Build(Interop.API.Common.Models.Display.ProformaDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProformaDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.ProformaDetailPage(model, delegationAction);
        }
    }
}
