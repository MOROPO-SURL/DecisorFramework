namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class DesignationEmploymentContract : Contract.AbstractEmploymentContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DesignationResolutionId))]
        public DesignationResolution Resolution { get; set; }
        public System.Guid DesignationResolutionId { get; set; }
    }
}