namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientTrainingServiceOrder : Contract.AbstractTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TrainingLegalClientContractId))]
        public LegalClientServicingContract Contract { get; set; }
        public int TrainingLegalClientContractId { get; set; }
    }
}
