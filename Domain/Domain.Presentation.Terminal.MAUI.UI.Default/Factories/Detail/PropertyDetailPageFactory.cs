namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PropertyDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PropertyDisplayModel> Build(Interop.API.Common.Models.Display.PropertyDisplayModel model, System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PropertyDetailPage(model, delegationAction);
        }
    }
}
