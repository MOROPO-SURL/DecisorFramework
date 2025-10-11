using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PropertiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Property, System.Guid, PropertyInputModel, PropertyDisplayModel, PropertyFilterModel>
    {
        private readonly IEntityRepository<PropertySpace, System.Guid> spaceRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public PropertiesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<PostalContactItem, System.Guid> postalContactRepository, IEntityRepository<PropertySpace, System.Guid> spaceRepository, IEntityRepository<Property, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertiesController> localizer, Microsoft.Extensions.Logging.ILogger<PropertiesController> logger) : base(repository, localizer, logger)
        {
            this.spaceRepository = spaceRepository;
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

            model.Images = entity.ImageBridges.Select(bridge =>
            {
                var _model = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            model.Spaces = entity.Spaces.OrderBy(entity => entity.Name).ToArray().Select(_entity =>
            {
                var _model = new PropertySpaceDisplayModel();

                _model.Import(_entity);

                if (_entity.FeatureImage != null)
                {
                    _model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.FeatureImage.ContentType);
                }

                return _model;
            }).ToArray();

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

            foreach (var _model in model.IncomingImageItems)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(_model.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                var _entity = imageRepository.Add(new Image
                {
                    ContentType = _model.ContentType,
                    Length = _model.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Property: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(_entity.Id, _model.ContentData, _model.ContentType);

                entity.ImageBridges.Add(new PropertyImageBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            foreach (var _model in model.IncomingSpaces)
            {
                var _entity = _model.Export();

                _entity.PropertyId = entity.Id;

                if (_model.FeatureImage != null)
                {
                    using var imageMemoryStream = new System.IO.MemoryStream(_model.FeatureImage.ContentData);

                    using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                    using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                    _entity.FeatureImage = imageRepository.Add(new Image
                    {
                        ContentType = _model.FeatureImage.ContentType,
                        Length = _model.FeatureImage.ContentData.LongLength,
                        Width = imageSkBitmap.Width,
                        Height = imageSkBitmap.Height,
                        About = string.Format("Image for Property Space: {0}", _model.Id)
                    }, User.Identity.Name, false);

                    imageFileManager.SaveImageFileContent(_entity.FeatureImage.Id, _model.FeatureImage.ContentData, _model.FeatureImage.ContentType);
                }

                spaceRepository.Add(_entity, User.Identity.Name, false);
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

            #region Image Items

            foreach (var _model in model.OutgoingImagetItems)
            {
                var bridge = entity.ImageBridges.First(bridge => bridge.SternId == _model.Id);

                imageRepository.Delete(bridge.Stern, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingImageItems)
            {
                using var imageMemoryStream = new System.IO.MemoryStream(_model.ContentData);

                using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                var _entity = imageRepository.Add(new Image
                {
                    ContentType = _model.ContentType,
                    Length = _model.ContentData.LongLength,
                    Width = imageSkBitmap.Width,
                    Height = imageSkBitmap.Height,
                    About = string.Format("Image for Property: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(_entity.Id, _model.ContentData, _model.ContentType);

                entity.ImageBridges.Add(new PropertyImageBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            #endregion

            #region Spaces

            foreach (var _model in model.OutgoingSpaces)
            {
                spaceRepository.Delete(new PropertySpace { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionSpaces)
            {
                var _entity = spaceRepository.Get(_model.Id); 
                
                _model.Mergue(_entity);

                if (_model.FeatureImage != null)
                {
                    using var imageMemoryStream = new System.IO.MemoryStream(_model.FeatureImage.ContentData);

                    using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                    using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                    _entity.FeatureImage = imageRepository.Add(new Image
                    {
                        ContentType = _model.FeatureImage.ContentType,
                        Length = _model.FeatureImage.ContentData.LongLength,
                        Width = imageSkBitmap.Width,
                        Height = imageSkBitmap.Height,
                        About = string.Format("Image for Property Space: {0}", _model.Id)
                    }, User.Identity.Name, false);

                    imageFileManager.SaveImageFileContent(_entity.FeatureImage.Id, _model.FeatureImage.ContentData, _model.FeatureImage.ContentType);
                }

                spaceRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingSpaces)
            {
                var _entity = _model.Export();

                _entity.PropertyId = entity.Id;

                if (_model.FeatureImage != null)
                {
                    using var imageMemoryStream = new System.IO.MemoryStream(_model.FeatureImage.ContentData);

                    using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

                    using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

                    _entity.FeatureImage = imageRepository.Add(new Image
                    {
                        ContentType = _model.FeatureImage.ContentType,
                        Length = _model.FeatureImage.ContentData.LongLength,
                        Width = imageSkBitmap.Width,
                        Height = imageSkBitmap.Height,
                        About = string.Format("Image for Property Space: {0}", _model.Id)
                    }, User.Identity.Name, false);

                    imageFileManager.SaveImageFileContent(_entity.FeatureImage.Id, _model.FeatureImage.ContentData, _model.FeatureImage.ContentType);
                }

                spaceRepository.Add(_entity, User.Identity.Name, false);
            }

            #endregion
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

                foreach (var _model in model.OutgoingImagetItems)
                {
                    var _entity = new Image { Id = _model.Id };

                    imageRepository.Delete(_entity, User.Identity.Name);

                    imageFileManager.DeleteImageFile(_entity);
                }

                foreach (var _model in model.OutgoingSpaces)
                {
                    if (_model.FeatureImage == null) continue;

                    var _entity = new Image { Id = _model.FeatureImage.Id };

                    imageRepository.Delete(_entity, User.Identity.Name);

                    imageFileManager.DeleteImageFile(_entity);
                }
            }
            catch { }
        }
    }
}
