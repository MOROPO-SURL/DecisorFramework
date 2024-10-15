using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Essential.Persistence.Entities
{
	public class BankAgency : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
	{
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ImageId")]
        public Image Image { get; set; }
        public System.Guid? ImageId { get; set; }

        public string About { get; set; }
    }
}

