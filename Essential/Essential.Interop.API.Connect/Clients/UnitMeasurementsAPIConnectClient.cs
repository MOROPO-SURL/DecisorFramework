namespace MOROPO.Framework.Decisor.Essential.Interop.API.Connect.Clients
{
    public class UnitMeasurementsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.UnitMeasurement, System.Guid, Common.Models.Input.UnitMeasurementInputModel, Common.Models.Display.UnitMeasurementDisplayModel>
    {
        public UnitMeasurementsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/unitmeasurements";
    }
}
