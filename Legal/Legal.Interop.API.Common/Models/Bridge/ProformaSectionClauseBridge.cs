namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Bridge
{
    public class ProformaSectionClauseBridge
    {
        public Display.SectionDisplayModel Section { get; set; }

        public System.Collections.Generic.List<Display.ClauseDisplayModel> Clauses { get; set; } = new System.Collections.Generic.List<Display.ClauseDisplayModel>();
    }
}
