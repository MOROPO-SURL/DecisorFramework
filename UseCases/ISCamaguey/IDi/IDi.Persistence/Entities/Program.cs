namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class Program : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(320)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Alias { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public ProgramKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefId))]
        public Framework.Decisor.Domain.Persistence.Entities.PersonContact Chief { get; set; }
        public System.Guid ChiefId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ManagerId))]
        public Framework.Decisor.Domain.Persistence.Entities.OrganizationContact Manager { get; set; }
        public System.Guid ManagerId { get; set; }

        public string Description { get; set; }

        public System.Collections.Generic.ICollection<ProgramExpectResult> ExpectResults { get; set ; }
    }
}
