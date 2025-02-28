using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PropertiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Property, System.Guid, PropertyInputModel, PropertyDisplayModel>
    {
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public PropertiesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<PostalContactItem, System.Guid> postalContactRepository, IEntityRepository<Property, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertiesController> localizer, Microsoft.Extensions.Logging.ILogger<PropertiesController> logger) : base(repository, localizer, logger)
        {
            this.postalContactRepository = postalContactRepository;
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.municipalityRepository = municipalityRepository;
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Property, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override System.Func<Property, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override PropertyDisplayModel EntityToDisplayModel(Property entity)
        {
            var model = base.EntityToDisplayModel(entity);

            var municipality = municipalityRepository.Get((entity.PostalContact.Location as MunicipalityLocation).MunicipalityId.Value);

            model.PostalContact.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

            model.PostalContact.Municipality.Import(municipality);

            if (model.FeatureImage != null)
            {
                model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Property entity, PropertyInputModel model)
        {
            base.PreCreate(entity, model);

            var municipalityLocation = municipalityLocationRepository.FindOneBy(_entity => _entity.MunicipalityId == model.PostalContact.MunicipalityId);

            if (municipalityLocation == null)
            {
                municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                {
                    MunicipalityId = model.PostalContact.MunicipalityId
                }, User.Identity.Name, false);
            }

            entity.PostalContact = postalContactRepository.Add(new PostalContactItem
            {
                Id = System.Guid.NewGuid(),
                Label = model.PostalContact.Label,
                Address = model.PostalContact.Address,
                ZipCode = model.PostalContact.ZipCode,
                Latitude = model.PostalContact.Latitude,
                Longitude = model.PostalContact.Longitude,
                LocationId = municipalityLocation.Id
            }, User.Identity.Name, false);

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
                    About = string.Format("Image for Property: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PreEdit(Property entity, PropertyInputModel model)
        {
            base.PreEdit(entity, model);

            var municipalityLocation = municipalityLocationRepository.FindOneBy(_entity => _entity.MunicipalityId == model.PostalContact.MunicipalityId);

            if (municipalityLocation == null)
            {
                municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                {
                    MunicipalityId = model.PostalContact.MunicipalityId
                }, User.Identity.Name, false);
            }

            entity.PostalContact.Label = model.PostalContact.Label;
            entity.PostalContact.Address = model.PostalContact.Address;
            entity.PostalContact.ZipCode = model.PostalContact.ZipCode;
            entity.PostalContact.Latitude = model.PostalContact.Latitude;
            entity.PostalContact.Longitude = model.PostalContact.Longitude;
            entity.PostalContact.LocationId = municipalityLocation.Id;

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
                    About = string.Format("Image for Property: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
            }
        }

        protected override void PostEdit(Property entity, PropertyInputModel model)
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
