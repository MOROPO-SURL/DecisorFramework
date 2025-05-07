using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VehiclesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Vehicle, System.Guid, VehicleInputModel, VehicleDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public VehiclesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Vehicle, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehiclesController> localizer, Microsoft.Extensions.Logging.ILogger<VehiclesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Vehicle, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override System.Func<Vehicle, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override VehicleDisplayModel EntityToDisplayModel(Vehicle entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.FeatureImage != null)
            {
                model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Vehicle entity, VehicleInputModel model)
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
                    About = string.Format("Image for Vehicle: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PreEdit(Vehicle entity, VehicleInputModel model)
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
                    About = string.Format("Image for Vehicle: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PostEdit(Vehicle entity, VehicleInputModel model)
        {
            base.PostEdit(entity, model);

            try
            {
                if (model.FeatureImage != null)
                {
                    var oldLogoImage = imageRepository.Get(model.FeatureImage.Id);

                    imageRepository.Delete(oldLogoImage, User.Identity.Name);

                    imageFileManager.DeleteImageFile(oldLogoImage);
                }
            }
            catch { }
        }
    }
}