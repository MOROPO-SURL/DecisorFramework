using MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Servicing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Servicing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ServicesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Service, System.Guid, ServiceInputModel, ServiceDisplayModel, ServiceFilterModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public ServicesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Service, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ServicesController> localizer, Microsoft.Extensions.Logging.ILogger<ServicesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Service, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ServiceDisplayModel EntityToDisplayModel(Service entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.FeatureImage != null)
            {
                model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Service entity, ServiceInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.FeatureImage != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImage.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.FeatureImage = imageRepository.Add(new Image
                {
                    ContentType = model.FeatureImage.ContentType,
                    Length = model.FeatureImage.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Service: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PreEdit(Service entity, ServiceInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.FeatureImage != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImage.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.FeatureImage = imageRepository.Add(new Image
                {
                    ContentType = model.FeatureImage.ContentType,
                    Length = model.FeatureImage.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Service: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PostEdit(Service entity, ServiceInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.FeatureImage != null)
            {
                var oldLogoImage = imageRepository.Get(model.FeatureImage.Id);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }
        }
    }
}

