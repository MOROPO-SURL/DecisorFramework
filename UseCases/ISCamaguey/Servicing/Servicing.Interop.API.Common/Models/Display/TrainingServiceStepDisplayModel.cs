namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class TrainingServiceStepDisplayModel : Contract.AbstractServiceStepDisplayModel<Persistence.Entities.TrainingServiceStep>
    {
        public TrainingServiceStepDisplayModel[] Children { get; set; }
    }
}
