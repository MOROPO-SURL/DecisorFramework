using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NamingResolutionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<NamingResolution, long, NamingResolutionInputModel, NamingResolutionDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public NamingResolutionsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<NamingResolution, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<NamingResolutionsController> localizer, Microsoft.Extensions.Logging.ILogger<NamingResolutionsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NamingResolution, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NamingResolution, object> GetOrderSelector()
        {
            return entity => 1000 * entity.Id + entity.At.Year;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(long key)
        {
            return NotFound();
        }

        protected override NamingResolutionDisplayModel EntityToDisplayModel(NamingResolution entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.NamedEmployee.Image != null)
            {
                model.NamedEmployee.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.NamedEmployee.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
