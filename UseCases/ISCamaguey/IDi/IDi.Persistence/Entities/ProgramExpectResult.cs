namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProgramExpectResult : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(2048)]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProgramId))]
        public Program Program { get; set; }
        public System.Guid ProgramId { get; set; }
    }
}
