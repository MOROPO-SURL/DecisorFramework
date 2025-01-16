namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class SchoolingDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SchoolingDisplayModel, Pages.Detail.SchoolingDetailPage>
    {
        public Pages.Detail.SchoolingDetailPage Build(Interop.API.Common.Models.Display.SchoolingDisplayModel model, System.Action<System.Action> delegationAction = null, System.Action<Interop.API.Common.Models.Display.SchoolingDisplayModel> completationFeedbackAction = null)
        {
            return new Pages.Detail.SchoolingDetailPage(model);
        }
    }
}