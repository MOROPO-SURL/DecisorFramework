namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class NaturalBusinessKindDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel, Pages.Detail.NaturalBusinessKindDetailPage>
    {
        public Pages.Detail.NaturalBusinessKindDetailPage Build(Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.NaturalBusinessKindDetailPage(model);
        }
    }
}