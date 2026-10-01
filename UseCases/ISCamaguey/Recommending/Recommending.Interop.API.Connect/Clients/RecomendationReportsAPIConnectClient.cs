namespace MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Connect.Clients
{
    public sealed class RecomendationReportsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.RecomendationReport, System.Guid, Common.Models.Input.RecomendationReportInputModel, Common.Models.Display.RecomendationReportDisplayModel, Common.Models.Filter.RecomendationReportFilterModel>
    {
        public RecomendationReportsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/recommending/recomendationreports";
    }
}