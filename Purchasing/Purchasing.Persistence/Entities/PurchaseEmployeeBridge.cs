namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseEmployeeBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Purchase, System.Guid, Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Purchase Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.Employee Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public System.Guid RoleId { get; set; }
    }
}
