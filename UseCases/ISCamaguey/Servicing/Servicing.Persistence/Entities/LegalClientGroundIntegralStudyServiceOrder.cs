namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientGroundIntegralStudyServiceOrder : Contract.AbstractGroundIntegralStudyServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyLegalClientContractId))]
        public LegalClientServicingContract Contract { get; set; }
        public System.Guid GroundIntegralStudyLegalClientContractId { get; set; }
    }
}
