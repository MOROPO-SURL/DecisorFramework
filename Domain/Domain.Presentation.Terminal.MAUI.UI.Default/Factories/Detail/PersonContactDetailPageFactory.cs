namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PersonContactDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonContactDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PersonContactDisplayModel> Build(Interop.API.Common.Models.Display.PersonContactDisplayModel model, System.Action<Interop.API.Common.Models.Display.PersonContactDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PersonContactDetailPage(model, delegationAction);
        }
    }
}
