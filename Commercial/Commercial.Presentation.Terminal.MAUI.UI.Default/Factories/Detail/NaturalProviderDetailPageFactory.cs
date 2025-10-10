namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalProviderDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> Build(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalProviderDetailPage(model, delegationAction);
        }
    }
}
