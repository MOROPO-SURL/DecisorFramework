using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/financial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class BankAgenciesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<BankAgency, System.Guid, BankAgencyInputModel, BankAgencyDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public BankAgenciesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<BankAgency, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BankAgenciesController> localizer, Microsoft.Extensions.Logging.ILogger<BankAgenciesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<BankAgency, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<BankAgency, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override BankAgencyDisplayModel EntityToDisplayModel(BankAgency entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Image != null)
            {
                model.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(BankAgency entity, BankAgencyInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.Image != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.Image.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.Image.ContentType,
                    Length = model.Image.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Bank Agency: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PreEdit(BankAgency entity, BankAgencyInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.Image != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.Image.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.Image.ContentType,
                    Length = model.Image.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Bank Agency: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PostEdit(BankAgency entity, BankAgencyInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.Image != null)
            {
                var oldLogoImage = imageRepository.Get(model.Image.Id);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }
        }

        protected override void PostDelete(BankAgency entity)
        {
            base.PostDelete(entity);

            if (entity.ImageId != null)
            {
                var oldImage = imageRepository.Get(entity.ImageId.Value);

                imageRepository.Delete(oldImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldImage);
            }
        }
    }
}
