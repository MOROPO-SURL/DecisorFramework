namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Models.View.Report.Standard.Shared;

public class SalaryStandardStatsSharedStandardReportViewModel
{
    public Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.SalaryStandardDisplayModel SalaryStandard { get; set; }

    public WorkPositionKindStatsSharedStandardReportViewModel[] WorkPositionKindStats { get; set; }

    public int Total { get; set; }

    public int F { get; set; }
}
