namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeaseContractSpaceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalClientPropertyLeaseContract, int, Domain.Persistence.Entities.PropertySpace, System.Guid>
    {
        public int ProwId { get; set; }
        public LegalClientPropertyLeaseContract Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PropertySpace Stern { get; set; }
    }
}