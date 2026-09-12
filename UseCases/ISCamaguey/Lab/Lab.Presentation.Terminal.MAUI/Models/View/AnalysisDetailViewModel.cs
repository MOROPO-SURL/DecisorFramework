using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.View;

public record class AnalysisDetailViewModel(AnalysisDisplayModel Target, IEnumerable<AnalysisQualityCheckDisplayModel> QualityChecks);
