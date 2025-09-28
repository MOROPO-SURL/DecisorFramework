namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientTrainingServiceOrder : Contract.AbstractTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TrainingLegalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid TrainingLegalClientId { get; set; }
    }
}
