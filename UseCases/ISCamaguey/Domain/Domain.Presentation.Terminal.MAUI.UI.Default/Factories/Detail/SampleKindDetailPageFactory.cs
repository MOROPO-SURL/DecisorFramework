using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class SampleKindDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<SampleKindDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<SampleKindDisplayModel> Build(SampleKindDisplayModel model, System.Action<SampleKindDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.SampleKindDetailPage(model);
        }
    }
}