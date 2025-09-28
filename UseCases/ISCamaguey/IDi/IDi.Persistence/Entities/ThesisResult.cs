namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Title))]
        public string Title { get; set; }

        public System.Collections.Generic.List<ThesisResultResearcherBridge> ResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultResearcherBridge>();
    }
}
