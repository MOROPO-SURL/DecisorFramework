using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/legal/[controller]")]
    [ApiController]
    public class SectionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<Section, System.Guid, SectionInputModel, SectionDisplayModel>
    {
        public SectionsController(Guama.Core.Persistence.Repositories.IEntityRepository<Section, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SectionsController> localizer, Microsoft.Extensions.Logging.ILogger<SectionsController> logger) : base(repository, localizer, logger)
        {
        }

        public override ActionResult<SectionDisplayModel[]> Get()
        {
            return Ok(Repository.GetAll().ToArray().OrderBy(entity => entity.GetTreePriority()).Select(entity => EntityToDisplayModel(entity)).ToArray());
        }

        public override ActionResult<PaginationModel<SectionDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            int num = Repository.Count();
            
            var result = new PaginationModel<SectionDisplayModel>
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

                result = new PaginationModel<SectionDisplayModel>
                {
                    Limit = limit,
                    Page = sheet,
                    HasPrevious = (sheet > 1),
                    HasNext = (sheet < num3),
                    MaxPageCount = num3,
                    List = Repository.GetAll().ToArray().Skip((sheet - 1) * limit).Take(limit).OrderBy(entity => entity.GetTreePriority()).Select(entity => EntityToDisplayModel(entity)).ToList()
                };
            }

            // TODO Remove debug wath line !!
            //var @case = Repository.GetAll().ToArray().Skip((sheet - 1) * limit).Take(limit).OrderBy(entity => entity.GetTreePriority()).Select(entity => entity.GetTreePriority()).ToArray();

            return Ok(result);
        }

        protected override SectionDisplayModel EntityToDisplayModel(Section entity)
        {
            entity.FillParent(Repository);

            return base.EntityToDisplayModel(entity);
        }
    }
}
