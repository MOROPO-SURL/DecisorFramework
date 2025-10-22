namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class GroundIntegralStudyServiceEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<GroundIntegralStudyService, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public GroundIntegralStudyService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Decisor.Domain.Persistence.Entities.Employee Stern { get; set; }
    }
}
