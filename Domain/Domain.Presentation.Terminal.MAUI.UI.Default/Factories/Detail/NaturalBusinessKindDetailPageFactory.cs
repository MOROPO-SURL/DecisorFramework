namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class NaturalBusinessKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel> Build(Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.NaturalBusinessKindDetailPage(model);
        }
    }
}