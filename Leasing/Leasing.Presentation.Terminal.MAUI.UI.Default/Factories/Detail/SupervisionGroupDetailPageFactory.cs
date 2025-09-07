namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class SupervisionGroupDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, Pages.Detail.SupervisionGroupDetailPage>
    {
        public Pages.Detail.SupervisionGroupDetailPage Build(Interop.API.Common.Models.Display.SupervisionGroupDisplayModel model, System.Action<Interop.API.Common.Models.Display.SupervisionGroupDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.SupervisionGroupDetailPage(model, delegationAction);
        }
    }
}