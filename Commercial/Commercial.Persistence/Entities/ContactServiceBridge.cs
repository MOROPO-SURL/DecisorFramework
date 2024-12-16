namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ContactServiceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractContact, System.Guid, Servicing.Persistence.Entities.Service, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractContact Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Servicing.Persistence.Entities.Service Stern { get; set; }
    }
}
