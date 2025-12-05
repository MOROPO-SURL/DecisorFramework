namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class UnitMeasurementsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.UnitMeasurement, System.Guid, Common.Models.Input.UnitMeasurementInputModel, Common.Models.Display.UnitMeasurementDisplayModel, Common.Models.Filter.UnitMeasurementFilterModel>
    {
        public UnitMeasurementsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/unitmeasurements";

        public virtual System.Threading.Tasks.Task<Common.Models.Display.UnitMeasurementDisplayModel[]> GetReleatedsAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.Display.UnitMeasurementDisplayModel[]>($"{TargetController}/releateds/{key}");
        }
    }
}