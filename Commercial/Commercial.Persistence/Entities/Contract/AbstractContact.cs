namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public abstract class AbstractContact : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.Collections.Generic.List<ContactProductBridge> ProductBridges { get; set; } = new System.Collections.Generic.List<ContactProductBridge>();

        public System.Collections.Generic.List<ContactServiceBridge> ServiceBridges { get; set; } = new System.Collections.Generic.List<ContactServiceBridge>();
    }
}
