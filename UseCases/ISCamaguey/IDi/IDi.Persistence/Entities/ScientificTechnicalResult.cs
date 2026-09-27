namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ScientificTechnicalResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public ScientificTechnicalResultKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string RegistrationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid? ProjectId { get; set; }
    }
}
