using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Bridge
{
    public class ProformaSectionClauseBridgeModel
    {
        public SectionDisplayModel Section { get; set; }

        public System.Collections.Generic.List<ClauseDisplayModel> Clauses { get; set; } = new System.Collections.Generic.List<ClauseDisplayModel>();
    }
}
