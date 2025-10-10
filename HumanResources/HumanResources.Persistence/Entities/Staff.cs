namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Staff : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StructureId))]
        public Domain.Persistence.Entities.Structure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MainWorkforceId))]
        public Workforce MainWorkforce { get; set; }
        public System.Guid MainWorkforceId { get; set; }

        public System.Collections.Generic.List<StaffWorkforceBridge> AlternativeWorkforceBridges { get; set; } = new System.Collections.Generic.List<StaffWorkforceBridge>();
    }
}