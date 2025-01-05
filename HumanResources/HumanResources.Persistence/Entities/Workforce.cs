namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Workforce : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public Domain.Persistence.Entities.Structure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public System.Collections.Generic.List<WorkforceOrganizationalUnityVacantBridge> OrganizationalUnityVacantBridges { get; set; } = new System.Collections.Generic.List<WorkforceOrganizationalUnityVacantBridge>();
    }
}
