using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class PropertyLeasePropousalsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<PropertyLeasePropousal, System.Guid, PropertyLeasePropousalInputModel, PropertyLeasePropousalDisplayModel>
    {
        private readonly IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository;

        public PropertyLeasePropousalsController(IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository, IEntityRepository<PropertyLeasePropousal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeasePropousalsController> localizer, ILogger<PropertyLeasePropousalsController> logger) : base(repository, localizer, logger)
        {
            this.spaceLeasePropousalRepository = spaceLeasePropousalRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PropertyLeasePropousal, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PropertyLeasePropousal, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override PropertyLeasePropousalDisplayModel EntityToDisplayModel(PropertyLeasePropousal entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            if (model.Property.FeatureImage != null)
            {
                model.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Property.FeatureImage.ContentType);
            }

            model.Property.Spaces = entity.Property.Spaces.OrderBy(entity => entity.Name).ToArray().Select(_entity =>
            {
                var _model = new PropertySpaceDisplayModel();

                _model.Import(_entity);

                if (_entity.FeatureImage != null)
                {
                    _model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.FeatureImage.ContentType);
                }

                return _model;
            }).ToArray();

            model.SpacePropousals = spaceLeasePropousalRepository.FindBy(_entity => _entity.PropertyLeasePropousalId == entity.Id).OrderBy(entity => entity.PropertySpace.Name).ToArray().Select(_entity =>
            {
                var _model = new PropertySpaceLeasePropousalDisplayModel();

                _model.Import(_entity);

                if (_entity.PropertySpace.FeatureImage != null)
                {
                    _model.Space.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.PropertySpace.FeatureImage.ContentType);
                }

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(PropertyLeasePropousal entity, PropertyLeasePropousalInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingSpaces)
            {
                var _entity = _model.Export();

                _entity.PropertyLeasePropousalId = entity.Id;

                spaceLeasePropousalRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(PropertyLeasePropousal entity, PropertyLeasePropousalInputModel model)
        {
            base.PreEdit(entity, model);

            #region Spaces

            foreach (var _model in model.OutgoingSpaces)
            {
                spaceLeasePropousalRepository.Delete(new PropertySpaceLeasePropousal { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingSpaces)
            {
                var _entity = _model.Export();

                _entity.PropertyLeasePropousalId = entity.Id;

                spaceLeasePropousalRepository.Add(_entity, User.Identity.Name, false);
            }

            #endregion
        }
    }
}
