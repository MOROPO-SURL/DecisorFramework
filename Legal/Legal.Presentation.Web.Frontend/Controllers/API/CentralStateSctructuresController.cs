using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/legal/[controller]")]
    [ApiController]
    public class CentralStateStructuresController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<CentralStateStructure, System.Guid, CentralStateStructureInputModel, CentralStateStructureDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public CentralStateStructuresController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<CentralStateStructure, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CentralStateStructuresController> localizer, Microsoft.Extensions.Logging.ILogger<CentralStateStructuresController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<CentralStateStructure, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<CentralStateStructure, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override CentralStateStructureDisplayModel EntityToDisplayModel(CentralStateStructure entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Identity.Image != null)
            {
                model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(CentralStateStructure entity, CentralStateStructureInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.Image != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.Image.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.Identity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.Image.ContentType,
                    Length = model.Image.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Central State Sctructure: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PreEdit(CentralStateStructure entity, CentralStateStructureInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.Image != null)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(model.Image.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                entity.Identity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.Image.ContentType,
                    Length = model.Image.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Central State Sctructure: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PostEdit(CentralStateStructure entity, CentralStateStructureInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.Image != null)
            {
                var oldLogoImage = imageRepository.Get(model.Image.Id);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }
        }
    }
}
