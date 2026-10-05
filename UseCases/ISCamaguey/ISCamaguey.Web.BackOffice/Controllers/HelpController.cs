using Microsoft.AspNetCore.Mvc;

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Controllers;

public sealed class HelpController : Controller
{
    public IActionResult Index() => View();
}
