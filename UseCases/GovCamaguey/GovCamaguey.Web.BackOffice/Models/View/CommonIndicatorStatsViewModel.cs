using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View;

public class CommonIndicatorStatsViewModel
{
    public string Name { get; set; }

    public double Amount { get; set; }

    public UnitMeasurement UnitMeasurement { get; set; }

    public double ReferenceResult { get; set; }

    public double LastResult { get; set; }
}
