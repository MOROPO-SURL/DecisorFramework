namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeasingPersonContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<LegalClientPropertyLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public LegalClientPropertyLeasing Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }
    }
}
