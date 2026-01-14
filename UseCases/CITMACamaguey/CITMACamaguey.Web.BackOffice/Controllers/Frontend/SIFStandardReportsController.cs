using Microsoft.AspNetCore.Mvc;
using MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Controllers.Frontend;

[Route("report/standard/sif")]
public class SIFStandardReportsController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
{
    private readonly Services.Contract.IHtmlToPdfService htmlToPdfService;
    private readonly Services.Contract.IViewRenderService viewRenderService;
    private readonly IEntityRepository<Framework.Decisor.HumanResources.Persistence.Entities.SalaryStandard, System.Guid> salaryStandardRepository;

    public SIFStandardReportsController(IEntityRepository<Framework.Decisor.HumanResources.Persistence.Entities.SalaryStandard, System.Guid> salaryStandardRepository, Services.Contract.IViewRenderService viewRenderService, Services.Contract.IHtmlToPdfService htmlToPdfService, Microsoft.Extensions.Localization.IStringLocalizer<SIFStandardReportsController> localizer, Microsoft.Extensions.Logging.ILogger<SIFStandardReportsController> logger) : base(localizer, logger)
    {
        this.htmlToPdfService = htmlToPdfService;
        this.viewRenderService = viewRenderService;
        this.salaryStandardRepository = salaryStandardRepository;
    }

    [Route("rh_08/web")]
    public IActionResult View_RH_08()
    {
        return View(GetMockModel());
    }

    [Route("rh_08/print")]
    public async System.Threading.Tasks.Task<IActionResult> Print_RH_08()
    {
        var htmlContent = await viewRenderService.RenderViewToStringAsync(
                "~/Views/SIFStandardReports/View_RH_08.cshtml",
                GetMockModel()
            );

        // Opciones para el PDF
        var pdfOptions = new Models.Options.PdfOptionsModel
        {
            PageSize = "A4",
            Orientation = Orientation.Landscape,
            Margins = new Models.MarginsModel { Top = 5, Right = 5, Bottom = 5, Left = 5 },
            EnableJavaScript = false,
            PrintBackground = false
        };

        // Generar PDF
        var pdfBytes = await htmlToPdfService.GeneratePdfFromHtmlAsync(htmlContent, pdfOptions);

        return File(pdfBytes, "application/pdf", $"Modelo-SIF-RH-08-{System.DateTime.Now.Ticks}.pdf");
    }

    private Models.View.Report.Standard.SIF.RH_8_SIFStandardReportViewModel GetMockModel()
    {
        var result = new Models.View.Report.Standard.SIF.RH_8_SIFStandardReportViewModel
        {
            SalaryStandardStats = salaryStandardRepository.FindBy(entity => !entity.Archived && entity.Enabled).OrderBy(entity => entity.Priority).ToArray().Select(entity =>
            {
                var _result = new Models.View.Report.Standard.Shared.SalaryStandardStatsSharedStandardReportViewModel
                {
                    SalaryStandard = new Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.SalaryStandardDisplayModel()
                };

                _result.SalaryStandard.Import(entity);

                return _result;
            }).ToArray()
        };

        return result;
    }
}
