namespace MOROPO.Framework.Decisor.Core.Persistence.Entities.Contract
{
	public abstract class AbstractContract : IFullFeatureEntity<System.Guid>
	{
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public BanckAccount DefaultBanckAccount { get; set; }
    }
}

