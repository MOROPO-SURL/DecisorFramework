using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public sealed class ScientificTechnicalResultIntroductionEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ScientificTechnicalResultIntroduction, System.Guid, Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ScientificTechnicalResultIntroduction Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Employee Stern { get; set; }
    }
}
