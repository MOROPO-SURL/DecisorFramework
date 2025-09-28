namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkingGroupTechniqueBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkingGroup, System.Guid, Domain.Persistence.Entities.Technique, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public WorkingGroup Prow { get ; set ; }
       
        public System.Guid SternId { get ; set ; }
        public Domain.Persistence.Entities.Technique Stern { get ; set ; }
    }
}
