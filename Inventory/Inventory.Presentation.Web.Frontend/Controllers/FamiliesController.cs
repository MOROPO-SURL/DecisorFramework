using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Route("api/inventory/[controller]")]
    [ApiController]
    public class FamiliesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Family, int, FamilyInputModel, FamilyDisplayModel>
    {
        public FamiliesController(Guama.Core.Persistence.Repositories.IEntityRepository<Family, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<FamiliesController> localizer, Microsoft.Extensions.Logging.ILogger<FamiliesController> logger)
            : base(repository, localizer, logger)
        {
        }

        public override ActionResult<FamilyDisplayModel[]> Get()
        {
            return Ok(Repository.FindBy(entity => !entity.Archived && entity.Enabled).ToArray().OrderBy(entity => entity.GetTreePriority()).Select(entity => EntityToDisplayModel(entity)).ToArray());
        }

        public override ActionResult<PaginationModel<FamilyDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            int num = Repository.Count(entity => !entity.Archived && entity.Enabled);

            var result = new PaginationModel<FamilyDisplayModel>
            {
                Limit = limit,
                Page = 0,
                HasNext = false,
                HasPrevious = false,
                List = []
            };

            if (num > 0)
            {
                int num2 = num % limit;
                int num3 = num / limit;
                if (num2 > 0)
                {
                    num3++;
                }

                if (sheet < 0 || sheet > num3)
                {
                    sheet = 1;
                }

                result = new PaginationModel<FamilyDisplayModel>
                {
                    Limit = limit,
                    Page = sheet,
                    HasPrevious = (sheet > 1),
                    HasNext = (sheet < num3),
                    MaxPageCount = num3,
                    List = Repository.FindBy(entity => !entity.Archived && entity.Enabled).ToArray().Skip((sheet - 1) * limit).Take(limit).OrderBy(entity => entity.GetTreePriority()).Select(entity => EntityToDisplayModel(entity)).ToList()
                };
            }

            return Ok(result);
        }

        public override ActionResult Delete(int key)
        {
            return NotFound();
        }

        protected override FamilyDisplayModel EntityToDisplayModel(Family entity)
        {
            entity.FillParent(Repository);

            return base.EntityToDisplayModel(entity);
        }
    }
}

