namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class WorkingGroupTechniqueBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.WorkingGroupTechniqueBridge, Entities.WorkingGroup, System.Guid, Domain.Persistence.Entities.Technique, System.Guid>
    {
        public WorkingGroupTechniqueBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TechniqueBridges;
        }
    }
}