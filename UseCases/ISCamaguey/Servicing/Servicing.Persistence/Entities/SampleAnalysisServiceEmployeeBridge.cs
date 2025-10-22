namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class SampleAnalysisServiceEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<SampleAnalysisService, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public SampleAnalysisService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Decisor.Domain.Persistence.Entities.Employee Stern { get; set; }
    }
}
