namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalClientDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalClientDetailPage(model, delegationAction);
        }
    }
}
