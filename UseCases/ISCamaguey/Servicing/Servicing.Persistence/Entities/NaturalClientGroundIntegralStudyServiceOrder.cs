namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientGroundIntegralStudyServiceOrder : Contract.AbstractGroundIntegralStudyServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyNaturalClientContractId))]
        public NaturalClientServicingContract Contract { get; set; }
        public int GroundIntegralStudyNaturalClientContractId { get; set; }
    }
}
