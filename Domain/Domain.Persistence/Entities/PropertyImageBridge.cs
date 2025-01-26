namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class PropertyImageBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Property, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Property Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Image Stern { get; set; }
    }
}
