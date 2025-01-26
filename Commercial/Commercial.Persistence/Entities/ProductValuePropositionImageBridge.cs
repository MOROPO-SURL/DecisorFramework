namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ProductValuePropositionImageBridge : Guama.Core.Persistence.Entities.Contract.IBridge<ProductValueProposition, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ProductValueProposition Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Image Stern { get; set; }
    }
}
