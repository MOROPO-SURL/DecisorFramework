using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities
{
    public class RecomendationReportEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<RecomendationReport, System.Guid, Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public RecomendationReport Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Employee Stern { get; set; }
    }
}
