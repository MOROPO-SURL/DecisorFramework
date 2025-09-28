namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkingGroupEmployeeBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkingGroup, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public WorkingGroup Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Framework.Decisor.Domain.Persistence.Entities.Employee Stern { get ; set ; }
    }
}
