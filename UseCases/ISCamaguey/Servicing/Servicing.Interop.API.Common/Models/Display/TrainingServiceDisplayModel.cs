namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class TrainingServiceDisplayModel : Contract.AbstractServiceDisplayModel<Persistence.Entities.TrainingService>
    {
        public TrainingServiceStepDisplayModel[] Steps { get; set; }
    }
}
