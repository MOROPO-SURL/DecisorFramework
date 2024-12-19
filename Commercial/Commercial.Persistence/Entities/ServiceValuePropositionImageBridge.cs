namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ServiceValuePropositionImageBridge : Guama.Core.Persistence.Entities.Contract.IBridge<ServiceValueProposition, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ServiceValueProposition Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Image Stern { get; set; }
    }
}
