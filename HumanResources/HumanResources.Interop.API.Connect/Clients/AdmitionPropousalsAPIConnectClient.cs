namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class AdmitionPropousalsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.AdmitionPropousal, System.Guid, Common.Models.Input.AdmitionPropousalInputModel, Common.Models.Display.AdmitionPropousalDisplayModel, Common.Models.Filter.AdmitionPropousalFilterModel>
    {
        public AdmitionPropousalsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/admitionpropousals";
    }
}