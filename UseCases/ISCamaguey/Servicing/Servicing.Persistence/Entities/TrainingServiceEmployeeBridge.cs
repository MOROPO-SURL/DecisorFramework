namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class TrainingServiceEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingService, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public TrainingService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Decisor.Domain.Persistence.Entities.Employee Stern { get; set; }
    }
}
