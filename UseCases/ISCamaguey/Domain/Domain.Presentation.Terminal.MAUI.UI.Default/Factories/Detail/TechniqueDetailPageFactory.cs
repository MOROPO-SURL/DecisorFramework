namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class TechniqueDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.TechniqueDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.TechniqueDisplayModel> Build(Interop.API.Common.Models.Display.TechniqueDisplayModel model, System.Action<Interop.API.Common.Models.Display.TechniqueDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.TechniqueDetailPage(model, delegationAction);
        }
    }
}
