using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
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
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PersonContactsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PersonContact, System.Guid, PersonContactInputModel, PersonContactDisplayModel>
    {
        private readonly IEntityRepository<EmailContactItem, System.Guid> emailContactRepository;
        private readonly IEntityRepository<PhoneContactItem, System.Guid> phoneContactRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactRepository;
        private readonly IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public PersonContactsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactRepository, IEntityRepository<PostalContactItem, System.Guid> postalContactRepository, IEntityRepository<PhoneContactItem, System.Guid> phoneContactRepository, IEntityRepository<EmailContactItem, System.Guid> emailContactRepository, IEntityRepository<PersonContact, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PersonContactsController> localizer, Microsoft.Extensions.Logging.ILogger<PersonContactsController> logger) : base(repository, localizer, logger)
        {
            this.emailContactRepository = emailContactRepository;
            this.phoneContactRepository = phoneContactRepository;
            this.postalContactRepository = postalContactRepository;
            this.webSiteContactRepository = webSiteContactRepository;
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.municipalityRepository = municipalityRepository;
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PersonContact, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override System.Func<PersonContact, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override PersonContactDisplayModel EntityToDisplayModel(PersonContact entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Identity.Image != null)
            {
                model.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
            }

            foreach (var _model in model.Identity.PostalContacts)
            {
                var municipality = municipalityRepository.Get(_model.Municipality.Id);

                _model.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                _model.Municipality.Import(municipality);
            }

            return model;
        }

        protected override void PreCreate(PersonContact entity, PersonContactInputModel model)
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
                    About = string.Format("Image for Person Contact: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }

            foreach (var _model in model.IncomingPostalContactItems)
            {
                var municipalityLocation = municipalityLocationRepository.FindOneBy(_entity => _entity.MunicipalityId == _model.MunicipalityId);

                if (municipalityLocation == null)
                {
                    municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                    {
                        MunicipalityId = _model.MunicipalityId
                    }, User.Identity.Name, false);
                }

                var _entity = postalContactRepository.Add(new PostalContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    Address = _model.Address,
                    ZipCode = _model.ZipCode,
                    Latitude = _model.Latitude,
                    Longitude = _model.Longitude,
                    LocationId = municipalityLocation.Id
                }, User.Identity.Name, false);

                entity.Identity.PostalContactItemBridges.Add(new PersonPostalContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            foreach (var _model in model.IncomingPhoneContactItems)
            {
                var _entity = phoneContactRepository.Add(new PhoneContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    PhoneNumber = _model.PhoneNumber
                }, User.Identity.Name, false);

                entity.Identity.PhoneContactItemBridges.Add(new PersonPhoneContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            foreach (var _model in model.IncomingEmailContactItems)
            {
                var _entity = emailContactRepository.Add(new EmailContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    EmailAddress = _model.EmailAddress
                }, User.Identity.Name, false);

                entity.Identity.EmailContactItemBridges.Add(new PersonEmailContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            foreach (var _model in model.IncomingWebContactItems)
            {
                var _entity = webSiteContactRepository.Add(new WebSiteContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    Url = _model.Url
                }, User.Identity.Name, false);

                entity.Identity.WebSiteContactItemBridges.Add(new PersonWebSiteContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }
        }

        protected override void PreEdit(PersonContact entity, PersonContactInputModel model)
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
                    About = string.Format("Image for Person Contact: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }

            #region Postal Contact Items

            foreach (var _model in model.OutgoingPostalContactItems)
            {
                var _entity = entity.Identity.PostalContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                postalContactRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionPostalContactItems)
            {
                var municipalityLocation = municipalityLocationRepository.FindOneBy(_entity => _entity.MunicipalityId == _model.MunicipalityId);

                if (municipalityLocation == null)
                {
                    municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                    {
                        MunicipalityId = _model.MunicipalityId
                    }, User.Identity.Name, false);
                }

                var _entity = entity.Identity.PostalContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _entity.Label = _model.Label;
                _entity.Address = _model.Address;
                _entity.ZipCode = _model.ZipCode;
                _entity.Latitude = _model.Latitude;
                _entity.Longitude = _model.Longitude;

                if (_entity.LocationId != municipalityLocation.Id)
                {
                    _entity.Location = null;
                    _entity.LocationId = municipalityLocation.Id;
                }

                postalContactRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingPostalContactItems)
            {
                var municipalityLocation = municipalityLocationRepository.FindOneBy(_entity => _entity.MunicipalityId == _model.MunicipalityId);

                if (municipalityLocation == null)
                {
                    municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                    {
                        MunicipalityId = _model.MunicipalityId
                    }, User.Identity.Name, false);
                }

                var _entity = postalContactRepository.Add(new PostalContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    Address = _model.Address,
                    ZipCode = _model.ZipCode,
                    Latitude = _model.Latitude,
                    Longitude = _model.Longitude,
                    LocationId = municipalityLocation.Id
                }, User.Identity.Name, false);

                entity.Identity.PostalContactItemBridges.Add(new PersonPostalContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            #endregion

            #region Phone Contact Items

            foreach (var _model in model.OutgoingPhoneContactItems)
            {
                var _entity = entity.Identity.PhoneContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                phoneContactRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionPhoneContactItems)
            {
                var _entity = entity.Identity.PhoneContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _entity.Label = _model.Label;
                _entity.PhoneNumber = _model.PhoneNumber;

                phoneContactRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingPhoneContactItems)
            {
                var _entity = phoneContactRepository.Add(new PhoneContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    PhoneNumber = _model.PhoneNumber
                }, User.Identity.Name, false);

                entity.Identity.PhoneContactItemBridges.Add(new PersonPhoneContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            #endregion

            #region Email Contact Items

            foreach (var _model in model.OutgoingEmailContactItems)
            {
                var _entity = entity.Identity.EmailContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                emailContactRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionEmailContactItems)
            {
                var _entity = entity.Identity.EmailContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _entity.Label = _model.Label;
                _entity.EmailAddress = _model.EmailAddress;

                emailContactRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingEmailContactItems)
            {
                var _entity = emailContactRepository.Add(new EmailContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    EmailAddress = _model.EmailAddress
                }, User.Identity.Name, false);

                entity.Identity.EmailContactItemBridges.Add(new PersonEmailContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            #endregion

            #region Web Contact Items

            foreach (var _model in model.OutgoingWebContactItems)
            {
                var _entity = entity.Identity.WebSiteContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                webSiteContactRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionWebContactItems)
            {
                var _entity = entity.Identity.WebSiteContactItemBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _entity.Label = _model.Label;
                _entity.Url = _model.Url;

                webSiteContactRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingWebContactItems)
            {
                var _entity = webSiteContactRepository.Add(new WebSiteContactItem
                {
                    Id = System.Guid.NewGuid(),
                    Label = _model.Label,
                    Url = _model.Url
                }, User.Identity.Name, false);

                entity.Identity.WebSiteContactItemBridges.Add(new PersonWebSiteContactItemBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            #endregion
        }

        protected override void PostEdit(PersonContact entity, PersonContactInputModel model)
        {
            base.PostEdit(entity, model);

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
    }
}
