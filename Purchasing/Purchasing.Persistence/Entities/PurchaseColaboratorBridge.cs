namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseColaboratorBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Purchase, System.Guid, Essential.Persistence.Entities.Colaborator, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Purchase Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Essential.Persistence.Entities.Colaborator Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public System.Guid RoleId { get; set; }
    }
}
