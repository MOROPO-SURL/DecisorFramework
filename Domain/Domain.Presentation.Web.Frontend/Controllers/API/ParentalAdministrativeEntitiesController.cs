using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/administrative_entities/parental")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ParentalAdministrativeEntitiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<AdministrativeEntity, System.Guid, AdministrativeEntityInputModel, AdministrativeEntityParentalDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public ParentalAdministrativeEntitiesController(IImageFileManagerFacade imageFileManager, IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<AdministrativeEntity, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ParentalAdministrativeEntitiesController> localizer, Microsoft.Extensions.Logging.ILogger<ParentalAdministrativeEntitiesController> logger)
            : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
            this.changeNotificationRepository = changeNotificationRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<AdministrativeEntity, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<AdministrativeEntity, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override AdministrativeEntityParentalDisplayModel EntityToDisplayModel(AdministrativeEntity entity)
        {
            var result = base.EntityToDisplayModel(entity);

            if (entity.ParentId != null) result.Parent = GetParent(entity);

            return result;
        }

        protected override void PreCreate(AdministrativeEntity entity, AdministrativeEntityInputModel model)
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
                    About = string.Format("Image for Structure: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PostCreate(AdministrativeEntity entity, AdministrativeEntityInputModel model)
        {
            base.PostCreate(entity, model);

            this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
        }

        protected override void PreEdit(AdministrativeEntity entity, AdministrativeEntityInputModel model)
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
                    About = string.Format("Image for Structure: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }
        }

        protected override void PostEdit(AdministrativeEntity entity, AdministrativeEntityInputModel model)
        {
            base.PostEdit(entity, model);

            this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);

            try
            {
                if (model.Image != null)
                {
                    var oldLogoImage = imageRepository.Get(model.Image.Id);

                    imageRepository.Delete(oldLogoImage, User.Identity.Name);

                    imageFileManager.DeleteImageFile(oldLogoImage);
                }
            }
            catch { }
        }

        private AdministrativeEntityParentalDisplayModel GetParent(AdministrativeEntity entity)
        {
            var parent = Repository.Get(entity.ParentId.Value);

            var model = new AdministrativeEntityParentalDisplayModel();

            model.Import(parent);

            if (parent.ParentId != null) model.Parent = GetParent(parent);

            return model;
        }
    }
}
