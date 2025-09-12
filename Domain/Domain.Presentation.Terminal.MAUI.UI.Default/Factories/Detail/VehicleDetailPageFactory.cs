namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class VehicleDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.VehicleDisplayModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleDisplayModel> Build(Interop.API.Common.Models.Display.VehicleDisplayModel model, System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.VehicleDetailPage(model, delegationAction);
        }
    }
}
