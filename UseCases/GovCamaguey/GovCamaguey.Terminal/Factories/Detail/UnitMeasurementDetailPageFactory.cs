namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class UnitMeasurementDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, UI.Pages.Detail.UnitMeasurementDetailPage>
    {
        public UI.Pages.Detail.UnitMeasurementDetailPage Build(Interop.API.Common.Models.Display.UnitMeasurementDisplayModel model, System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, int?> delegationAction = null)
        {
            return new UI.Pages.Detail.UnitMeasurementDetailPage(model, delegationAction);
        }
    }
}
