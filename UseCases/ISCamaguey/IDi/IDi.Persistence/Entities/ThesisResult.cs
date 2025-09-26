using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResult : Contract.AbstractBaseResult
    {
        System.Collections.Generic.List<ThesisResultAbstractBaseResearcherBridge> AbstractBaseResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultAbstractBaseResearcherBridge>();
    }
}
