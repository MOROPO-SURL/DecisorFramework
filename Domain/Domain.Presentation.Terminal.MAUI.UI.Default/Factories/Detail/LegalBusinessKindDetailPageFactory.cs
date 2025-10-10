namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class LegalBusinessKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel> Build(Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.LegalBusinessKindDetailPage(model);
        }
    }
}
