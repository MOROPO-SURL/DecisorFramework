using System;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View;

public class ObjectivesIndicatorsStatsReportViewModel
{
    public DateTime ReferenceAt { get; set; }

    public CommonIndicatorStatsViewModel[] Indicators { get; set; }

    public ObjectiveStatsViewModel[] Objectives { get; set; }
}
