namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class SectionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SectionDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.SectionDisplayModel> Build(Interop.API.Common.Models.Display.SectionDisplayModel model, System.Action<Interop.API.Common.Models.Display.SectionDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.SectionDetailPage(model, delegationAction);
        }
    }
}