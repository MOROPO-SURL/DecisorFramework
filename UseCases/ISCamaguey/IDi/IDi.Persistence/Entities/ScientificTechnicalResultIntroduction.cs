namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ScientificTechnicalResultIntroduction : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Scenery { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResultId))]
        public ScientificTechnicalResult Result { get ; set ; }
        public System.Guid ResultId { get ; set ; }

        public System.Collections.Generic.List<ScientificTechnicalResultIntroductionEmployeeBridge> EmployeeBridges { get; set; } = new System.Collections.Generic.List<ScientificTechnicalResultIntroductionEmployeeBridge>();
    }
}
