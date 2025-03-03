using System.Linq;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/inventory/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ProductsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Product, System.Guid, ProductInputModel, ProductDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<Family, int> familyRepository;
        private readonly IEntityRepository<Classification, System.Guid> classificationRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public ProductsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Classification, System.Guid> classificationRepository, IEntityRepository<Family, int> categoryRepository, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Product, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductsController> localizer, Microsoft.Extensions.Logging.ILogger<ProductsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.familyRepository = categoryRepository;
            this.classificationRepository = classificationRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Product, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Product, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProductDisplayModel EntityToDisplayModel(Product entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.FeatureImage != null)
            {
                model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
            }

            if (entity.FamilyId != null)
            {
                entity.Family = familyRepository.Get(entity.FamilyId.Value);

                entity.Family.FillParent(familyRepository);

                model.Category = new FamilyDisplayModel();

                model.Category.Import(entity.Family);
            }

            model.Classifications = classificationRepository.FindBy(_entity => _entity.ProductId == entity.Id && !_entity.Archived && _entity.Enabled).ToArray().Select(_entity =>
            {
                var _model = new ClassificationDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(Product entity, ProductInputModel model)
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
                    About = string.Format("Image for Product: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }

            foreach (var _model in model.IncomingClassificationItems)
            {
                var _entity = _model.Export();

                _entity.ProductId = entity.Id;

                classificationRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(Product entity, ProductInputModel model)
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
                    About = string.Format("Image for Product: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }

            foreach (var _model in model.OutgoingClassificationItems)
            {
                classificationRepository.Delete(entity.Classifications.First(_entity => _entity.Id == _model.Id), User.Identity.Name, false);
            }

            foreach (var _model in model.EditionClassificationItems)
            {
                var _entity = entity.Classifications.First(_entity => _entity.Id == _model.Id);

                _model.Mergue(_entity);

                classificationRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingClassificationItems)
            {
                var _entity = _model.Export();

                _entity.ProductId = entity.Id;

                classificationRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PostEdit(Product entity, ProductInputModel model)
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
