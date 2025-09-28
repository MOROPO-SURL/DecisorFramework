namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientTrainingServiceOrder : Contract.AbstractTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TrainingNaturalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid TrainingNaturalClientId { get; set; }
    }
}