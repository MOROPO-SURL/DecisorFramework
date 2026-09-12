using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.View;

public partial class AssessmentDetailViewModel() : Framework.Caney.MVVM.Core.Models.BaseBindableModel
{
    private AssessmentDisplayModel target;

    public AssessmentDisplayModel Target { get => target; set => SetProperty(ref target, value); }

    public IEnumerable<AnalysisDetailViewModel> Analises { get; set; }
}