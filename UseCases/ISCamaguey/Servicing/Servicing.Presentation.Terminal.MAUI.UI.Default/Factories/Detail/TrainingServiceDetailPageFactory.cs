namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class TrainingServiceDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.TrainingServiceDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.TrainingServiceDisplayModel> Build(Interop.API.Common.Models.Display.TrainingServiceDisplayModel model, System.Action<Interop.API.Common.Models.Display.TrainingServiceDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.TrainingServiceDetailPage(model, delegationAction);
        }
    }
}
