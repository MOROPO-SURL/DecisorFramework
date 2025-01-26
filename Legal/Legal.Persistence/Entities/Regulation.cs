namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Regulation : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProclamationId))]
        public Proclamation Proclamation { get; set; }
        public System.Guid ProclamationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public RegulationKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StructureId))]
        public CentralStateStructure Structure { get; set; }
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Reference { get; set; } // Código Ej: GOC-2024-440-O78

        public string Description { get; set; }
    }
}
