namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
    public class UnitMeasurementsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.UnitMeasurement, System.Guid, Common.Models.Input.UnitMeasurementInputModel, Common.Models.Display.UnitMeasurementDisplayModel>
    {
        public UnitMeasurementsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/inventory/unitmeasurements";

        public virtual System.Threading.Tasks.Task<Common.Models.Display.UnitMeasurementDisplayModel[]> GetReleatedsAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.Display.UnitMeasurementDisplayModel[]>($"{TargetController}/releateds/{key}");
        }
    }
}
