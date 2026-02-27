namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class DesignationEmploymentContract : Contract.AbstractEmploymentContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResolutionId))]
        public DesignationResolution Resolution { get; set; }
        public System.Guid? ResolutionId { get; set; }
    }
}