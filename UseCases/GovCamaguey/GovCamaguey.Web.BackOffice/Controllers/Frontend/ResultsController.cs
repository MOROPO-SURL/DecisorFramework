using Microsoft.AspNetCore.Mvc;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/governance/[controller]")]
    [ApiController]
    public class ResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<Result, long, Interop.API.Common.Models.Input.ResultInputModel, Interop.API.Common.Models.Display.ResultDisplayModel, Interop.API.Common.Models.Filter.ResultFilterModel>
    {
        public ResultsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Result, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<ResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ResultsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Func<Result, object> GetOrderSelector()
        {
            return entity => entity.At;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override ActionResult Delete(long key)
        {
            return NotFound();
        }

        [HttpPost("lasts/by/indicators")]
        public ActionResult LastsByObjective([FromBody] System.Guid[] keys)
        {
            var rawResult = new List<Result>();

            foreach (var key in keys) 
            {
                var last = Repository.GetAll().Where(entity => entity.IndicatorId == key).OrderByDescending(entity => entity.At).FirstOrDefault();

                if (last == null) continue;

                rawResult.Add(last);
            }

            return Ok(rawResult.Select(entity => EntityToDisplayModel(entity)).ToArray());
        }
    }
}
