using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Bridge
{
    public class ProformaSectionClauseBridgeModel
    {
        public SectionDisplayModel Section { get; set; }

        public ClauseDisplayModel[] Clauses { get; set; }
    }
}
