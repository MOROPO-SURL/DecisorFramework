namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientTrainingServiceOrder : Contract.AbstractTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TrainingNaturalClientContractId))]
        public NaturalClientServicingContract Contract { get; set; }
        public int TrainingNaturalClientContractId { get; set; }
    }
}