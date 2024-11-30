using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/purchasing/[controller]")]
    [ApiController]
    public class NaturalProvidersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<NaturalProvider, System.Guid, NaturalProviderInputModel, NaturalProviderDisplayModel>
    {
        private readonly IEntityRepository<EmailContactItem, System.Guid> emailContactRepository;
        private readonly IEntityRepository<PhoneContactItem, System.Guid> phoneContactRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactRepository;
        private readonly IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public NaturalProvidersController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactRepository, IEntityRepository<PostalContactItem, System.Guid> postalContactRepository, IEntityRepository<PhoneContactItem, System.Guid> phoneContactRepository, IEntityRepository<EmailContactItem, System.Guid> emailContactRepository, IEntityRepository<NaturalProvider, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalProvidersController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalProvidersController> logger) : base(repository, localizer, logger)
        {
            this.emailContactRepository = emailContactRepository;
            this.phoneContactRepository = phoneContactRepository;
            this.postalContactRepository = postalContactRepository;
            this.webSiteContactRepository = webSiteContactRepository;
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalProvider, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override NaturalProviderDisplayModel EntityToDisplayModel(NaturalProvider entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Image != null)
            {
                model.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(NaturalProvider entity, NaturalProviderInputModel model)
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
                    About = string.Format("Image for Natural Provider: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }

            if (model.EmailContacts != null)
            {
                foreach (var item in model.EmailContacts)
                {
                    var _entity = emailContactRepository.Add(new EmailContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        EmailAddress = item.EmailAddress
                    }, User.Identity.Name, false);

                    entity.Identity.EmailContactItemBridges.Add(new PersonEmailContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.PhoneContacts != null)
            {
                foreach (var item in model.PhoneContacts)
                {
                    var _entity = phoneContactRepository.Add(new PhoneContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        PhoneNumber = item.PhoneNumber
                    }, User.Identity.Name, false);

                    entity.Identity.PhoneContactItemBridges.Add(new PersonPhoneContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.WebContacts != null)
            {
                foreach (var item in model.WebContacts)
                {
                    var _entity = webSiteContactRepository.Add(new WebSiteContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        Url = item.Url
                    }, User.Identity.Name, false);

                    entity.Identity.WebSiteContactItemBridges.Add(new PersonWebSiteContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.PostalContacts != null)
            {
                foreach (var item in model.PostalContacts)
                {
                    var municipalityLocation = municipalityLocationRepository.FindOneBy(__entity => __entity.MunicipalityId == item.Municipality.Id);

                    if (municipalityLocation == null)
                    {
                        municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                        {
                            MunicipalityId = item.Municipality.Id
                        }, User.Identity.Name, false);
                    }

                    var _entity = postalContactRepository.Add(new PostalContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        Address = item.Address,
                        ZipCode = item.ZipCode,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        LocationId = municipalityLocation.Id
                    }, User.Identity.Name, false);

                    entity.Identity.PostalContactItemBridges.Add(new PersonPostalContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }
        }

        protected override void PreEdit(NaturalProvider entity, NaturalProviderInputModel model)
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
                    About = string.Format("Image for Natural Provider: {0}", model.Id)
                }, User.Identity.Name, false);

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.Image.ContentData, model.Image.ContentType);
            }

            if (model.EmailContacts != null)
            {
                entity.Identity.EmailContactItemBridges.Clear();

                foreach (var item in model.EmailContacts)
                {
                    var _entity = emailContactRepository.Add(new EmailContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        EmailAddress = item.EmailAddress
                    }, User.Identity.Name, false);

                    entity.Identity.EmailContactItemBridges.Add(new PersonEmailContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.PhoneContacts != null)
            {
                entity.Identity.PhoneContactItemBridges.Clear();

                foreach (var item in model.PhoneContacts)
                {
                    var _entity = phoneContactRepository.Add(new PhoneContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        PhoneNumber = item.PhoneNumber
                    }, User.Identity.Name, false);

                    entity.Identity.PhoneContactItemBridges.Add(new PersonPhoneContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.WebContacts != null)
            {
                entity.Identity.WebSiteContactItemBridges.Clear();

                foreach (var item in model.WebContacts)
                {
                    var _entity = webSiteContactRepository.Add(new WebSiteContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        Url = item.Url
                    }, User.Identity.Name, false);

                    entity.Identity.WebSiteContactItemBridges.Add(new PersonWebSiteContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }

            if (model.PostalContacts != null)
            {
                entity.Identity.PostalContactItemBridges.Clear();

                foreach (var item in model.PostalContacts)
                {
                    var municipalityLocation = municipalityLocationRepository.FindOneBy(__entity => __entity.MunicipalityId == item.Municipality.Id);

                    if (municipalityLocation == null)
                    {
                        municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                        {
                            MunicipalityId = item.Municipality.Id
                        }, User.Identity.Name, false);
                    }

                    var _entity = postalContactRepository.Add(new PostalContactItem
                    {
                        Id = item.Id,
                        Label = item.Label,
                        Address = item.Address,
                        ZipCode = item.ZipCode,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        LocationId = municipalityLocation.Id
                    }, User.Identity.Name, false);

                    entity.Identity.PostalContactItemBridges.Add(new PersonPostalContactItemBridge
                    {
                        ProwId = entity.Id,
                        SternId = _entity.Id
                    });
                }
            }
        }

        protected override void PostEdit(NaturalProvider entity, NaturalProviderInputModel model)
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
