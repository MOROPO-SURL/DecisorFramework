namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class SchoolingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.Schooling, System.Guid, Common.Models.Display.SchoolingDisplayModel>
    {
        public SchoolingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/schoolings";
    }
}
