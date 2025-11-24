namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public abstract class AbstractTrainingServiceOrder : AbstractServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TrainingServiceId))]
        public TrainingService Service { get; set; }
        public System.Guid TrainingServiceId { get; set; }
    }
}