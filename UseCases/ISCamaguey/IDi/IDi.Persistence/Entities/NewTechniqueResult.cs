namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class NewTechniqueResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResultingTechniqueId))]
        public Domain.Persistence.Entities.Technique ResultingTechnique { get; set; }
        public System.Guid ResultingTechniqueId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PredecessorTechniqueId))]
        public Domain.Persistence.Entities.Technique PredecessorTechnique { get; set; }
        public System.Guid? PredecessorTechniqueId { get; set; }
    }
}
