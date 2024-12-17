namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ContactServiceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractContact, System.Guid, RequestableService, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractContact Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public RequestableService Stern { get; set; }
    }
}
