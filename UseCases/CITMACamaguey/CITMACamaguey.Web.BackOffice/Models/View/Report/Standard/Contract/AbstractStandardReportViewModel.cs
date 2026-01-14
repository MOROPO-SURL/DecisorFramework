namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Models.View.Report.Standard.Contract;

public abstract class AbstractStandardReportViewModel
{
    public System.DateTime EndedAt { get; set; } = System.DateTime.Now;

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get; set; }
}
