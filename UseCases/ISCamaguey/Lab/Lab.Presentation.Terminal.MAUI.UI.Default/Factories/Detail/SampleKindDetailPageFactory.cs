namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class SampleKindDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SampleKindDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.SampleKindDisplayModel> Build(Interop.API.Common.Models.Display.SampleKindDisplayModel model, System.Action<Interop.API.Common.Models.Display.SampleKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.SampleKindDetailPage(model);
        }
    }
}