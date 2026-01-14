namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Models.View.Report.Standard.SIF;

public class RH_8_SIFStandardReportViewModel : Contract.AbstractStandardReportViewModel
{
    public System.DateTime ReferedAt { get; set; }

    public Shared.SalaryStandardStatsSharedStandardReportViewModel[] SalaryStandardStats { get; set; }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

    // TODO Make possiball
    //public Framework.Decisor.Legal.Interop.API.Common.Models.Display.AprovalResolution Resolution { get; set; }
}