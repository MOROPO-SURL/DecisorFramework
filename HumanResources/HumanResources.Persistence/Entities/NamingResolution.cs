namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingResolution : Contract.AbstractIncorporationResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AdmitionPropousalId))]
        public AdmitionPropousal AdmitionPropousal { get; set; }
        public System.Guid AdmitionPropousalId { get; set; }
    }
}