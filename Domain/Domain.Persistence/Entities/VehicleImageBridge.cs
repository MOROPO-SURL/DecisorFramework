namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class VehicleImageBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Vehicle, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Vehicle Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Image Stern { get; set; }
    }
}
