using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Ocupation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public System.Guid StaffId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid VacantId { get; set; }

        public AbstractEmploymentContract Contract { get; set; }
        public int ContractId { get; set; }
    }
}
